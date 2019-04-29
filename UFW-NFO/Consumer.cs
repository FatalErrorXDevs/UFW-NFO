using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;

namespace UFW_NFO
{
    public class Consumer
    {
    
        public static bool isConsuming = true;
        public Consumer()
        {
            Thread thread = new Thread(Run);
            thread.Start();
        }

        private void Run()
        {
            while (isConsuming)
            {
                while (FileWatch.changeQue.TryDequeue(out NSPModel itemToProcess))
                {
                    Squirell.RemoveHeadersWithSquirrel(itemToProcess);
                }
                Thread.Sleep(200);
            }
        }
    }
}
    