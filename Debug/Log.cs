using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading; 

namespace TLog
{
    class Debug
    {
        private Manager.AppendFile logFile;
        private string logFilePath;
        private static Debug debugInstance;
        private Queue<string> logMessageQueue;
        private Thread logThread;
        private bool canExit = false;

        public enum MessageType
        {
            Information,
            Error,
            Warning,
        }

        private Debug(string logFilePath)
        {
            this.logFilePath = logFilePath;
            logFile = (Manager.AppendFile)Manager.Files.openFile(logFilePath, Manager.Files.AccessType.APPEND);
            logMessageQueue = new Queue<string>();
        }

        public static void Log(string message, params object[] fmt)
        {
            Log(MessageType.Information, message, fmt);
        }

        public static void Log(MessageType logLevel, string message, params object[] fmt)
        {
            if (debugInstance != null)
                debugInstance.logMessageQueue.Enqueue(String.Format("[{0}] {1}: {2}", DateTime.Now.ToString("hh:mm:ss"), logLevel.ToString(), String.Format(message, fmt)));
            else
                throw new NullReferenceException("Tried to log a message, but log queue is not initialized");
        }

        private void monitorLogQueue()
        {
            logFile.addLine("========== START ==========");
            while (!canExit || logMessageQueue.Count > 0)
            {
                if (logMessageQueue.Count > 0)
                    logFile.addLine(logMessageQueue.Dequeue());
                else
                    Thread.Sleep(100);
            }

            logFile.addLine("==========  END  ==========");
        }

        public static void onExit(object sender, EventArgs e)
        {
            if (debugInstance != null)
                debugInstance.canExit = true;
        }

        public static void Init(string logFilePath)
        {
            try
            {
                if (debugInstance == null)
                {
                    debugInstance = new Debug(logFilePath);
                    debugInstance.logThread = new Thread(new ThreadStart(debugInstance.monitorLogQueue));
                    debugInstance.logThread.Start();
                }
            }

            catch (Exception E)
            {
                throw new Exception("Could not initialize logging - " + E.Message);
            }
        }
    }
}
