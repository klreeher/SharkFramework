using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shark
{
    public class Logger
    {
        public static void Info(string msg)
        {
            Console.WriteLine(msg);
            Debug.WriteLine(msg);
        }

        public static void Error(string msg)
        {
            Console.Error.WriteLine(msg);
            Debug.WriteLine(msg);
        }

        public static void Info(string msg, params string[] args)
        {
            Console.WriteLine(msg, args);
            Debug.WriteLine(msg, args);
        }

        public static void Error(string msg, params string[] args)
        {
            Console.Error.WriteLine(msg, args);
            Debug.WriteLine(msg, args);
        }
    }
}
