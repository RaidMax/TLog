using System;

namespace TLog.Network
{
    class NetException : Exception
    {
        public NetException(string msg) : base (msg) { }
    }
}
