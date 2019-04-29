using System;
using System.IO;

namespace UFW_NFO
{
    public class Archiver
    {
        public static void ArchiveFile(NSPModel item)
        {
            DirectoryInfo hdDirectoryInWhichToSearch = new DirectoryInfo($"./out/{item.Name + item.Version}");
            FileInfo[] filesInDir = hdDirectoryInWhichToSearch.GetFiles("*" + item.Name + "*.*");

            foreach (FileInfo foundFile in filesInDir)
            {
                string fullName = foundFile.FullName;
                Console.WriteLine(fullName);
                return;
            }

            Console.WriteLine("failed to prcess file " + item.FileName);
            return;

        }
    }
}