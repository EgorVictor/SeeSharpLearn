using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleDelegate
{
    public delegate string WriteMessage(string message);

    public delegate string WriteMessageType(String message, LogType type);

    public delegate void WriteLog(String message);
    public delegate int DelegateWork(int time);
   
    public class Logger
    {
        public event WriteMessage Event_WriteMessage;
        public string WriteLog(string message)
        {
            Console.WriteLine($"{message}");
            return $"{message}调用完成";
        }

        public string WriteLog(string message, LogType Type)
        {
            Console.WriteLine($"{message},类型为{Type}");
            return $"{message}调用完成";
        }

        public void ActionWriteLog(string message,LogType type)
        {
            Console.WriteLine($"{message},类型为{type}");
        }

        public void ActionWriteLog(string message)
        {
            Console.WriteLine($"{message}");
        }

        public string OnEvent(string message)
        {
            return Event_WriteMessage?.Invoke(message);
        }

        public bool Compare(int value)
        {
            return value == 0;
        }

        public int TakeWork(int ms)
        {
            Console.WriteLine("开始调用TakeWork");
            Task.Delay(ms);
            Console.WriteLine("开始调用TakeWork调用完成");
            return ms;

        }

        public void MyAsyncCallback(IAsyncResult ar)
        {
            Console.WriteLine("IAsyncResult");
        }
    }

    public enum LogType
    {
        Info,
        Warning,
        Error
    }
}
