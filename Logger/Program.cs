using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger
{
    class Logger
    {
        Action<string> log;

        public void AddLogMethod(Action<string> logMethod)
        {
            log += logMethod;
        }

        public void Log(string message)
        {
            if (log != null)
                log(DateTime.Now + " " + message);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Logger log = new Logger();
            log.AddLogMethod(x => Console.WriteLine(x));
            log.AddLogMethod(x =>
                {
                    using (StreamWriter writer = new StreamWriter("log.txt"))
                    {
                        writer.WriteLine(x);
                    }
                });
            log.Log("ERROR!");
            Console.ReadLine();
        }
    }
}
