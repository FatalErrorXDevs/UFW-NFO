using System;
using System.IO;
using System.Security.Permissions;

namespace UFW_NFO
{
    class Program
    {

        public static void Main()
        {
            string[] args = Environment.GetCommandLineArgs();
            /*
            // If a directory is not specified, exit program.
             if (args.Length != 2)
             {
                 // Display the proper way to call the program.
                 Console.WriteLine("Usage: Watcher.exe (directory)");
                 return;
             } */

            FileWatch watch = new FileWatch("C:/switchtest");
            Consumer consumer = new Consumer();

        }
    }
}
