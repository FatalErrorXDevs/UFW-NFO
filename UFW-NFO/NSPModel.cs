using System;
using System.IO;
using System.Text.RegularExpressions;

namespace UFW_NFO
{
    public class NSPModel
    {
        //The Red Strings Club
        public string Name;
        // /some/paht/in/some/folder/The Red Strings Club [0100EB100D17C800][v65536].nsp
        public string Path;
        //[0100EB100D17C800]
        public string ID;
        //[v65536]
        public string Version;
        //The Red Strings Club [0100EB100D17C800][v65536].nsp
        public string FileName;

        public NSPModel(string name, string path, string iD, string version, string fileName)
        {
            Name = name;
            Path = path;
            ID = iD;
            Version = version;
            FileName = fileName;
        }

        public static explicit operator NSPModel(FileSystemEventArgs e)
        {
            var itemName = e.Name;
            // split fullname into name, version and id
            var result = Regex.Split(itemName, @"(?=\[)");
            result[0] = result[0].Trim();
            result[2] = result[2].Replace(".nsp", "");
            result[2] = new Regex(@"\[(.*?)\]").Match(result[2]).Value;
            return new NSPModel(result[0], e.FullPath, result[1], result[2], e.Name);
        }
    }
}
