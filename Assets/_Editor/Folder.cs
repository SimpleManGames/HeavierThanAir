using System.Collections.Generic;
using System.IO;

namespace Simplicity
{
    public class Folder
    {
        public string DirPath { get; private set; }
        public string ParentPath { get; private set; }
        public string name;
        public List<Folder> subFolders;

        public Folder Add(string folderName)
        {
            Folder subFolder = null;
            if (ParentPath.Length > 0)
                subFolder = new Folder(folderName, ParentPath + Path.DirectorySeparatorChar + name);
            else
                subFolder = new Folder(folderName, name);

            subFolders.Add(subFolder);
            return subFolder;
        }

        public Folder(string name, string dirPath)
        {
            this.name = name;
            ParentPath = dirPath;
            DirPath = ParentPath + Path.DirectorySeparatorChar + this.name;
            subFolders = new List<Folder>();
        }
    }
}