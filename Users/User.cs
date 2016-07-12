using System;

namespace TLog.Users
{
    [Serializable]
    abstract class User
    {
        public enum Type
        {
            Administrator,
            Student_Worker,
        }

        public string firstName { get; protected set; }
        public string lastName { get; protected set; }
        public string userName { get; protected set; }
        public string Email { get; protected set; }
        public bool Activated { get; protected set; }
        public bool activationRequested { get; protected set; }
        public Type Class { get; protected set; }

        public TNumber ID { get; protected set; }
        public long secretKey { get; protected set; }
        public string passKey { get; protected set; }

        public DateTime lastLogon { get; protected set; }
        public DateTime lastLogoff { get; protected set; }
        public DateTime lastModified { get; protected set; }
        public int totalLogins { get; protected set; }
        public bool loggedIn { get; protected set; }
        public bool markedForDeletion { get; private set; }

        public User(string fName, string lName, string TNum, string uName, string Em, long sKey)
        {
            firstName = fName;
            lastName = lName;
            userName = uName;
            Email = Em;
            ID = TNumber.convertTo(TNum);
            secretKey = sKey;
            activationRequested = false;
            lastModified = DateTime.Now;
            passKey = "default";
        }

        public bool updatePassKey(string pass)
        {
            if (pass.Length > 0 && pass != "default")
            {
                passKey = pass;
                lastModified = DateTime.Now;
            }

            return passKey == pass;
        }

        public bool isSecretKey(string sK)
        {
            try
            {
                return Convert.ToUInt64(sK) == (ulong)secretKey;
            }

            catch (Exception)
            {
                return false;
            }
        }

        public TimeSpan sessionTime()
        {
            if (lastLogoff > lastLogon)
                return (lastLogoff - lastLogon);
            return new TimeSpan();
        }

        public string sessionTimeStr()
        {
            TimeSpan sessTime = sessionTime();

            if (sessTime.TotalHours >= 1)
                return Math.Round(sessTime.TotalHours, 0) + " hours";
            else
                return Math.Round(sessTime.TotalMinutes, 0) + " minutes";
        }

        public virtual void Update(string fName, string lName, string TNum, long sKey, string Un, string Em, Type classification)
        {
            if (fName.Length > 0)
                firstName = fName;
            if (lName.Length > 0)
                lastName = lName;
            if (TNum.Length > 0)
                ID = TNumber.convertTo(TNum);
            if (sKey > 0)
                secretKey = sKey;
            if (Un.Length > 0)
                userName = Un;
            if (Em.Length > 0)
                Email = Em;

            Class = classification;
            lastModified = DateTime.Now;
        }

        public virtual void Update(string fName, string lName, string TNum, long sKey, string Un, string Em, Type classification, int maxHours)
        {
            Update(fName, lName, TNum, sKey, Un, Em, classification);
        }

        public void requestActivation()
        {
            if (!activationRequested)
                activationRequested = true;
            lastModified = DateTime.Now;
        }

        public void Activate()
        {
            Activated = true;
            activationRequested = false;
            lastModified = DateTime.Now;
        }

        public void Deactivate()
        {
            Activated = false;
            activationRequested = false;
            lastModified = DateTime.Now;
        }

        public void Delete()
        {
            markedForDeletion = true;
            lastModified = DateTime.Now;
        }

        public bool Search(string searchTerm)
        {
            if (firstName.Contains(searchTerm) || lastName.Contains(searchTerm) || userName.Contains(searchTerm) || Email.Contains(searchTerm) || ID.ToString().Contains(searchTerm))
                return true;
            return false;
        }

        public virtual void logOn()
        {
            lastLogon = DateTime.Now;
            totalLogins++;
            Debug.Log("User {0} logging on date={1}", ID, lastLogon.DayOfWeek + "_" + lastLogon.ToString("MM.dd.yy"));
            lastModified = DateTime.Now;
        }

        public virtual void logOff()
        {
            lastLogoff = DateTime.Now;
            Debug.Log("User {0} logging off date={1}", ID, lastLogon.DayOfWeek + "_" + lastLogon.ToString("MM.dd.yy"));
            lastModified = DateTime.Now;
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() == typeof(User))
                return ((User)(obj)).ID == ID && ((User)(obj)).secretKey == secretKey;

            return false;
        }

        public override string ToString()
        {
            return firstName + ' ' + lastName;
        }
    }
}
