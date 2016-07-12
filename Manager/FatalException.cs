using System;

namespace TLog.Manager
{
    class FatalException : Exception
    {
        public FatalException(string reason) : base(reason) { }
    }
}
