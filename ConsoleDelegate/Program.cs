using System;
using System.Threading.Tasks;
using Microsoft.VisualBasic;

namespace ConsoleDelegate
{
    class Program
    {

        static void Main(string[] args)
        {
            //C# 1.0
            //Logger.WriteMessage = LoggingMethods.LogToConsole;
            //C# 2.0或更高
            //Logger.WriteMessage = delegate { Console.WriteLine("123"); };
            //C# 3.0或更高
            //Logger.WriteMessage = name => { Console.WriteLine("123"); };
            Logger logger = new();

            //推断调用
            WriteMessage write = logger.WriteLog;
            var result = write.Invoke("委托示例1");
            Console.WriteLine(result);

            Console.WriteLine();

            //匿名函数调用
            WriteMessage anonymous = delegate (string message)
            {
                Console.WriteLine(message);
                return $"{message}调用完成";
            };
            result = anonymous?.Invoke("匿名委托");
            Console.WriteLine(result);

            Console.WriteLine();

            //多播委托调用
            WriteMessage multicast = write;
            multicast += anonymous;
            result = multicast.Invoke("多播委托");
            Console.WriteLine(result);

            Console.WriteLine();

            //事件
            logger.Event_WriteMessage += Logger_Event_WriteMessage;
            result=logger.OnEvent("触发事件");
            Console.WriteLine(result);

            Console.WriteLine();

            //泛型委托: Func
            Func<string, LogType,string> func =logger.WriteLog;
            result = func("Func调用",LogType.Warning);
            Console.WriteLine(result);

            Console.WriteLine();

            //泛型委托: Action
            Action<string> action1 = logger.ActionWriteLog;
            action1("action示例1");

            Action<string, LogType> action2 = logger.ActionWriteLog;
            action2("action示例2", LogType.Error);

            Console.WriteLine();

            //泛型委托: Predicate
            Predicate<int> orPredicate = logger.Compare;
            bool bo= orPredicate(1);
            Console.WriteLine(bo.ToString());

            Console.WriteLine();

            Console.WriteLine("Net5 不支持BeginInvoke");
            //Net5 不支持Delegate BeginInvoke
            // DelegateWork work = logger.TakeWork;
            //AsyncCallback callBack = logger.MyAsyncCallback;
            //IAsyncResult asyncResult = work.BeginInvoke(1000, callBack,"");
            //int workResult = work.Invoke(1000);
            //while (!asyncResult.IsCompleted)
            //{
            //    Console.WriteLine("等待......");
            //    Task.Delay(100);
            //}
            //work.EndInvoke(asyncResult);
            //Console.WriteLine($"委托调用结果{asyncResult}");

        }



        private static string Logger_Event_WriteMessage(string message)
        {
            Console.WriteLine(message);
            return "事件处理完成";
        }
    }
}
