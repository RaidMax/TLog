using System;

namespace TLog.Users
{
    [Serializable]
    class Administrator : User
    {
        public Administrator(string fName, string lName, string TNum, long sKey, string Un, string Em) : base (fName, lName, TNum, Un, Em, sKey)
        {
            Class = Type.Administrator;
            Activated = true;
        }
    }
}
