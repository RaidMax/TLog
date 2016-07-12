using System;
using System.Collections.Generic;
using System.Threading;

namespace TLog.Manager
{
    class Cron
    {
        public static int failedSaves = 0;
        public static bool connectionGood = false;
        public static bool syncInProgress = false;

        public static void Start()
        {
            var saving = new Thread(new ThreadStart(saveDatabase));
            saving.Start();
        }

        private static void saveDatabase()
        {
            while (!Main.Instance.shutdownRequest)
            {
                // fixme
                Thread.Sleep(5000);
                Debug.Log("Beginning cron run...");
                try
                {
                    if (Main.Instance.serverSync != null && connectionGood)
                    {
                        syncInProgress = true;
                        if (Main.Instance.pendingUpload)
                        {
           
                            foreach (var u in Main.Instance.activeUsers)
                                Debug.Log("Uploading user {0} [success={1}]", u.userName, Main.Instance.serverSync.Upload(Serialization.ObjectAsBytes(u)));
                            Main.Instance.pendingUpload = false;
                        }

                        // pull users incase of update

                        int success = 0, fail = 0;
                        foreach (var u in Serialization.BytesAsObject<List<Users.User>>(Main.Instance.serverSync.Download()))
                        {
                            if (Main.Instance.mergeUser(u))
                                success++;
                            else
                                fail++;
                        }
          
                        Debug.Log(Debug.MessageType.Information, "User merge complete [success={0}] [fail/skip={1}]", success, fail);
                        syncInProgress = false;
                    }

                    // could cause race condition... fixme
                    Debug.Log("Saving users...");
                    Serialization.WriteToBinaryFile("activeUsers.db", Main.Instance.activeUsers);
                    Serialization.WriteToBinaryFile("archivedUsers.db", Main.Instance.archivedUsers);
                    Debug.Log("Saved {0} users", Main.Instance.activeUsers.Count + Main.Instance.archivedUsers.Count);
                    failedSaves = 0;
                }

                catch (Exception E) when (E is System.ServiceModel.EndpointNotFoundException || E is TimeoutException)
                {
                    failedSaves++;
                    Debug.Log(Debug.MessageType.Warning, "Failed to download users from server - " + E.Message);

                    if (failedSaves > 4)
                    {
                        Debug.Log(Debug.MessageType.Error, "Reached maximum number of download attempts,\nServer connection disabled!");
                        connectionGood = false;
                    }
                }

                catch (Exception E)
                {
                    failedSaves++;
                    Debug.Log(Debug.MessageType.Warning, "Failed to save users - " + E.Message);

                    if (failedSaves > 4)
                    {
                        Debug.Log(Debug.MessageType.Error, "Reached maximum number of save attempts!");
                        throw new FatalException("Unable to save user files!");
                    }
                }
            }
        }
    }
}
