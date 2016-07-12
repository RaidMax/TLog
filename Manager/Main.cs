using System;
using System.Collections.Generic;

namespace TLog.Manager
{
    class Main
    {
        public static Main Instance;
        public List<Users.User> archivedUsers;
        public List<Users.User> activeUsers;
        public Users.User lastUser;
        public bool shutdownRequest = false;
        public Network.WCFService.ISync serverSync { get; private set; }
        public bool pendingUpload;
        public  System.ServiceModel.ServiceHost serviceServer { get; private set; }

        public enum AuthType
        {
            LOG_ON,
            LOG_OFF,
        }

        public enum FailReason
        {
            ID_INVALID,
            ID_INACTIVE,
            ID_NOTALLOWED,
            ID_WAITINGFORACTIVATION,
            ID_UNRECOGNIZED,
            ID_WEEKLYHOURSLIMIT,
            ID_SEMESTERLYHOURSLIMIT,
            NULL,
        }

        public struct LoginResult
        {
            public bool success;
            public TimeSpan sessionTime;
            public AuthType type;
            public FailReason error;
            public Users.User currentUser;
        }

        private Main()
        {
            Debug.Init("tLog.log");
            Debug.Log("tLog Manager starting up...");
            Debug.Log("Current date is {0}", DateTime.Now.ToString("MM.dd.yyyy"));
            archivedUsers = new List<Users.User>();
            activeUsers = new List<Users.User>();

            Debug.Log("Loading users...");

            if (Files.Exists("student_accounts.csv"))
            {
                // fixme
                try
                {
                    Debug.Log("There appears to be a student database update, attempting to update...");
                    archivedUsers = CSV.getStudents();
                    Serialization.WriteToBinaryFile("archivedUsers.db", archivedUsers);
                    if (Files.Exists("student_accounts_processed.csv"))
                        System.IO.File.Delete("student_accounts_processed.csv");
                    System.IO.File.Move("student_accounts.csv", "student_accounts_processed.csv");
                    System.IO.File.Delete("student_accounts.csv");
                }

                catch (Exception E)
                {
                    Debug.Log(Debug.MessageType.Warning, "Could not load student database file - " + E.Message);
                }
            }

            else
            {
                Debug.Log("Student database appears to be up-to-date, skipping...");
            }

            try
            {
                var server = Network.WCFService.findServer();

                if (server != null)
                {
                    serverSync = Network.WCFService.Connect(server);
                    // test connection
                    try
                    {
                        serverSync.Download();
                        Cron.connectionGood = true;
                    }

                    catch (Exception e) when (e is System.ServiceModel.EndpointNotFoundException || e is TimeoutException)
                    {
                        Debug.Log(Debug.MessageType.Error, "Requested endpoint {0} is not currently listening!", server.ToString());
                        Cron.connectionGood = false;
                        serverSync = null;
                    }
                }

                else
                    serviceServer = Network.WCFService.Start();
            }

            catch (Network.NetException E)
            {
                onExit(null, null);
                throw new FatalException("Starting Manager failed - " + E.Message);
            }

            try
            {
                if (Files.Exists("activeUsers.db") && serverSync == null)
                    activeUsers = Serialization.ReadFromBinaryFile<List<Users.User>>("activeUsers.db");
                archivedUsers = Serialization.ReadFromBinaryFile<List<Users.User>>("archivedUsers.db");
            }

            catch (Exception E)
            {
                onExit(null, null);
                throw new FatalException("Starting Manager failed - " + E.Message);
            }

            if (activeUsers.Count == 0 && serverSync == null)
            {
                Debug.Log("No active users found, adding default user");
                activeUsers.Add(archivedUsers.Find(u=>u.userName == "mtsnyder42"));
                activeUsers.Find(u => u.userName == "mtsnyder42").Update("", "", "", -1, "", "", Users.User.Type.Administrator);
            }

            else
                Debug.Log("Loaded {0} users from file", archivedUsers.Count + activeUsers.Count);
        }

        public void onExit(object sender, EventArgs e)
        {
            Debug.Log("tLog Manager shutting down...");

            foreach (Users.User loggedUser in activeUsers.FindAll(u => u.loggedIn  == true))
                loggedUser.logOff();

            if (serviceServer != null)
                serviceServer.Close();

            shutdownRequest = true;
            Debug.onExit(sender, e);
        }

        public static void Init()
        {
            if (Instance == null)
                Instance = new Main();

            Cron.Start();
        }

        public List<Users.User> onlineUsers()
        {
            return activeUsers.FindAll(u => u.loggedIn);
        }

        public bool mergeUser(Users.User newUser)
        {
            var existingUser = activeUsers.Find(x => x.userName == newUser.userName);

            if (newUser.markedForDeletion && existingUser == null)
            {
                Debug.Log("Nonexistant user {0} marked for deletion, not adding", newUser.userName);
                return true;
            }

            if (existingUser != null)
            {
                if (newUser.markedForDeletion && existingUser.markedForDeletion)
                {
                    Debug.Log("Existing user {0} marked for deletion, removing from active users", newUser.userName);
                    activeUsers.RemoveAll(x => x.userName == newUser.userName);
                    archivedUsers.RemoveAll(x => x.userName == newUser.userName);
                    return true;
                }

                if (existingUser.lastModified < newUser.lastModified)
                {
                    Debug.Log(Debug.MessageType.Information, "Uploaded user {0} is newer than existing user, updating", newUser.userName);
                    Debug.Log("Count: " + activeUsers.Count);
                    activeUsers.RemoveAll(x => x.userName == newUser.userName);
                    activeUsers.Add(newUser);
                    Debug.Log("Count: " + activeUsers.Count);
                    return true;
                }

                else if (existingUser.lastModified > newUser.lastModified)
                {
                    Debug.Log(Debug.MessageType.Information, "Uploaded user {0} is older than existing user, marking out of date", newUser.userName);
                    pendingUpload = true;
                }

                else if (existingUser.lastModified == newUser.lastModified)
                    Debug.Log(Debug.MessageType.Information, "Uploaded user {0} is unchanged from existing user, skipping", newUser.userName);


                return false;
            }

            else
            {
                Debug.Log(Debug.MessageType.Information, "Uploaded user {0} is new, adding", newUser.userName);
                activeUsers.Add(newUser);
                return true;
            }
        }

        public bool[] mergeUsers(List<Users.User> users)
        {
            bool[] mergeSuccess = new bool[users.Count];

            int curIndex = 0;
            foreach (var u in users)
            {
                var existingUser = activeUsers.Find(x => x.userName == u.userName);
                if (existingUser != null)
                {
                    if (u.lastModified < existingUser.lastModified)
                    {
                        Debug.Log(Debug.MessageType.Information, "Uploaded user {0} is older than existing user, skipping", u.userName);
                        mergeSuccess[curIndex] = false;
                        curIndex++;
                        continue;
                    }

                    else if (u.lastModified == existingUser.lastModified)
                    {
                        Debug.Log(Debug.MessageType.Information, "Uploaded user {0} is unchanged from existing user, skipping", u.userName);
                        mergeSuccess[curIndex] = false;
                        curIndex++;
                        continue;
                    }

                    else
                    {
                        Debug.Log(Debug.MessageType.Information, "Uploaded user {0} is newer than existing user, updating", u.userName);
                        activeUsers.RemoveAll(x => x.userName == u.userName);
                        activeUsers.Add(u);
                        mergeSuccess[curIndex] = true;
                    }
                }

                else
                {
                    Debug.Log(Debug.MessageType.Information, "Uploaded user {0} is new, adding", u.userName);
                    activeUsers.Add(u);
                    mergeSuccess[curIndex] = true;
                }

                curIndex++;
            }

            return mergeSuccess;
        }

        public LoginResult Authenticate(string userID)
        {
            var Result = new LoginResult();
            Result.success = false;
            Result.sessionTime = new TimeSpan();

            try
            {
                if (userID.Length == 0)
                {
                    Result.error = FailReason.ID_INVALID;
                    return Result;
                }

                Users.User findUser = null;
                bool tNumAuth = false;
                if (userID.ToLower().Substring(0, 1) == "t")
                {
                    findUser = activeUsers.Find(u => u.ID.Equals(Users.TNumber.convertTo(userID)));
                    tNumAuth = true;
                }

                else
                {
                    if (userID != "default")
                        findUser = activeUsers.Find(u => u.passKey == userID);

                    if (findUser == null && userID.Length == 16)
                        findUser = activeUsers.Find(u => u.isSecretKey(userID));
                }

                if (findUser == null)
                {
                    Result.error = FailReason.ID_INACTIVE;

                    if (tNumAuth)
                    {
                        findUser = archivedUsers.Find(u => u.ID.Equals(Users.TNumber.convertTo(userID)));
                        if (findUser == null)
                            Result.error = FailReason.ID_UNRECOGNIZED;

                        else if (findUser.activationRequested)
                            Result.error = FailReason.ID_WAITINGFORACTIVATION;
                    }
                    else if (userID.Length == 16)
                    {
                        findUser = archivedUsers.Find(u => u.isSecretKey(userID));
                        if (findUser == null)
                            Result.error = FailReason.ID_UNRECOGNIZED;

                        else if (findUser.activationRequested)
                            Result.error = FailReason.ID_WAITINGFORACTIVATION;
                    }
                    else
                        Result.error = FailReason.ID_UNRECOGNIZED;
                }

                else
                {
                    Result.success = true;
                    Result.error = FailReason.NULL;
                    Result.type = (findUser.loggedIn) ? AuthType.LOG_OFF : AuthType.LOG_ON;

                    if (findUser.Class == Users.User.Type.Student_Worker)
                    {
                        var sw = (Users.StudentWorker)(findUser);
                        if (sw.weeklyHours() >= sw.maxHoursPerWeek)
                        {
                            Result.success = false;
                            Result.error = FailReason.ID_WEEKLYHOURSLIMIT;
                        }

                        if (sw.semesterHours() >= sw.maxHoursPerSemester)
                        {
                            Result.success = false;
                            Result.error = FailReason.ID_SEMESTERLYHOURSLIMIT;
                        }
                    }

                    // is admin
                    else
                    {
                        if (tNumAuth)
                        {
                            Result.success = false;
                            Result.error = FailReason.ID_NOTALLOWED;
                        }
                    }

                    if (findUser.loggedIn)
                    {
                        findUser.logOff();
                        pendingUpload = true;
                        Result.sessionTime = findUser.lastLogoff - findUser.lastLogon;
                    }

                    else
                    {
                        findUser.logOn();
                        pendingUpload = true;
                    }
                }

                Result.currentUser = findUser;
                lastUser = findUser;
            }

            catch (FormatException)
            {
                Result.error = FailReason.ID_INVALID;
            }

            catch (NullReferenceException)
            {
                Result.error = FailReason.ID_UNRECOGNIZED;
            }

            if (Result.error != FailReason.NULL)
                Debug.Log("Failed attempt at authenticating ID=\"{0}\" FailReason={1}", userID, Result.error);

            return Result;
        }
    }
}
