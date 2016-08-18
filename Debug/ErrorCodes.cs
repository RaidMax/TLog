using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TLog
{
    class ErrorCodes
    {
        private static Dictionary<int, string> CODES = new Dictionary<int, string>
        {
            {(int)Manager.Main.FailReason.ID_INACTIVE, "The entered ID is inactive." },
            {(int)Manager.Main.FailReason.ID_WAITINGFORACTIVATION, "The entered ID is awaiting activation" },
            {(int)Manager.Main.FailReason.ID_INVALID, "The entered ID is invalid." },
            {(int)Manager.Main.FailReason.ID_UNRECOGNIZED, "The entered ID is not recognized" },
            {(int)Manager.Main.FailReason.ID_WEEKLYHOURSLIMIT, "The entered ID has reached the maximum clocked hours this week" },
            {(int)Manager.Main.FailReason.ID_SEMESTERLYHOURSLIMIT, "The entered ID has reached the maximum clocked hours this week" },
            {(int)Manager.Main.FailReason.ID_NOTALLOWED, "Administrators must use secure authentication" },
        };
        
        public static string getString(int errorCode)
        {
            string codeStr = null;
            CODES.TryGetValue(errorCode, out codeStr);
            if (codeStr == null)
                codeStr = "Unknown error";

            return codeStr;
        }

        public static string getString(Manager.Main.FailReason errorCode)
        {
            return getString((int)errorCode);
        }
    }
}
