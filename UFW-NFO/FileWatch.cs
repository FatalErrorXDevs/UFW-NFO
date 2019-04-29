using System;
using System.Collections;
using System.Collections.Concurrent;
using System.IO;
using System.Threading;

namespace UFW_NFO
{
    public class FileWatch
    {
        public static FileSystemWatcher watcher;
        private static string Path;
        public static ConcurrentQueue<NSPModel> changeQue;
        public static bool isProducing = true;

        public FileWatch(string path)
        {
            changeQue = new ConcurrentQueue<NSPModel>();
            Path = path;
            Thread t = new Thread(Run);
            t.Start();
        }
        public static void Run()
        {
            // Create a new FileSystemWatcher and set its properties.
            using (watcher = new FileSystemWatcher())
            {
                watcher.Path = Path;

                // Watch for changes in LastAccess and LastWrite times, and
                // the renaming of files or directories.
                watcher.NotifyFilter = NotifyFilters.LastAccess
                                     | NotifyFilters.LastWrite
                                     | NotifyFilters.FileName
                                     | NotifyFilters.DirectoryName;

                // Only watch nsp files.
                watcher.Filter = "*.nsp";

                // Add event handlers.
                watcher.Created += OnChanged;

                // Begin watching.
                watcher.EnableRaisingEvents = true;

                // Wait for the user to quit the program.
                while (isProducing)
                {
                    Thread.Sleep(100);
                }
            }
        }

        private static NSPModel ConstructChangeObject(object source, FileSystemEventArgs eventAction)
        {
            return (NSPModel)eventAction;
        }

        // Define the event handlers.
        private static void OnChanged(object source, FileSystemEventArgs e)
        {
            // Specify what is done when a file is changed, created, or deleted.
            changeQue.Enqueue(FileWatch.ConstructChangeObject(source, e));
        }
    }
}
