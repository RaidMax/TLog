using System;
using System.Text;
using System.IO;

namespace TLog.Manager
{
    abstract class Files
    {
        public static bool Exists(string fileName)
        {
            return File.Exists(fileName);
        }

        public static Exception lastError { get; private set; }

        protected string filePath;
        protected FileStream rwStream;

        public enum AccessType
        {
            READ,
            WRITE,
            APPEND,
        }

        public static Files openFile(string filePath, AccessType openType)
        {
            Files newFile = null;
            switch (openType)
            {
                case AccessType.READ:
                    newFile = new ReadFile();
                    newFile.filePath = filePath;
                    break;
                case AccessType.WRITE:
                    break;
                case AccessType.APPEND:
                    newFile = new AppendFile();
                    newFile.filePath = filePath;
                    break;
                default:
                    break;
            }

            if (newFile == null)
                throw new NullReferenceException("File could not be opened");

            return newFile;
        }
    }

    class ReadFile : Files
    { 
        public ReadFile()
        {
            rwStream = File.OpenRead(filePath);
        }

        ~ReadFile()
        {
            if (rwStream != null)
                rwStream.Close();
        }

        public string[] readLines()
        {
            return File.ReadAllLines(filePath);
        }
    }

    class WriteFile : Files
    {
        public WriteFile()
        {
            try
            {
                rwStream = File.OpenWrite(filePath);
            }

            catch (Exception E)
            {
                throw new FileLoadException("Could not open " + filePath + " for writing - " + E.Message);
            }
        }

        public void writeLine(string line)
        {
  
        }
    }

    class AppendFile : Files
    {
        public void addLine(string Line)
        {
            try
            {
                byte[] lineBytes = Encoding.Default.GetBytes(Line + Environment.NewLine);
                rwStream = File.Open(filePath, FileMode.Append);
                rwStream.Write(lineBytes, 0, lineBytes.Length);
                rwStream.Flush();
                rwStream.Close();
            }

            catch (Exception E)
            {
                throw new FileLoadException("Could not open " + filePath + " for appending - " + E.Message);
            }
        }
    }

}
