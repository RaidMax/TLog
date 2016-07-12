using System;

namespace TLog.Users
{
    [Serializable]
    class TNumber
    {
        private char Prefix = 'T';
        public uint ID { get; private set; }

        private TNumber(string TNumStr)
        {
            if (TNumStr.Length < 2)
                throw new FormatException("Invalid T# length");
            if (!TNumStr.Substring(0, 1).Equals("T"))
                throw new FormatException("Invalid T# prefex");
            
            try
            {
                ID = UInt32.Parse(TNumStr.Substring(1));
            }
            
            catch (Exception)
            {
                throw new FormatException("Invalid T# values");
            }
        }

        public static TNumber convertTo(String TNumStr)
        {
            return new TNumber(TNumStr);
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() == typeof(TNumber))
                return ((TNumber)(obj)).ID == ID;
            return false;
        }
        public override string ToString()
        {
            return Prefix + ID.ToString();
        }
    }
}
