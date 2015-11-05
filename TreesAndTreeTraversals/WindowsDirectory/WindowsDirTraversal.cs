namespace WindowsDirectory
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class Program
    {
        private const string DirPath = @"C:\Windows\Microsoft.NET\";

        static void Main()
        {
            Folder root = new Folder(DirPath);
            Console.WriteLine("Root folder: " + root.Name);
            DirectoryInfo rootDir = new DirectoryInfo(DirPath);
            List<DirectoryInfo> dirList = new List<DirectoryInfo>();

            TraverseDir(rootDir, dirList);
            List<Folder> folderList = new List<Folder>();

            folderList.Add(new Folder(DirPath));
            foreach (var d in dirList)
            {
                Folder folder = new Folder(d.FullName);
                foreach (var subD in d.GetDirectories())
                {
                    var newFolder = new Folder(subD.FullName);
                    folder.ChildFolders.Add(newFolder);
                    newFolder.ParentFolder = folder;
                }

                foreach (var f in d.GetFiles())
                {
                    folder.Files.Add(new File
                    {
                        Name = f.FullName,
                        ParentFolder = folder,
                        Size = f.Length
                    });

                }

                folderList.Add(folder);
            }

            // Task 2

            List<File> exeFiles = new List<File>();
            foreach (var folder in folderList)
            {
                foreach (var file in folder.Files)
                {
                    if (file.Name.EndsWith(".exe"))
                    {
                        Console.WriteLine(file.Name);
                    }
                }
            }

            // Task 3

            var fSize = folderList.FirstOrDefault(f => f.Name == @"C:\Windows\Microsoft.NET\Framework");
            Console.WriteLine(fSize.Size());
        }

        private static void TraverseDir(DirectoryInfo root, List<DirectoryInfo> dirList)
        {
            FileInfo[] files = root.GetFiles();
            DirectoryInfo[] subDirs = root.GetDirectories();

            if (subDirs != null)
            {
                foreach (var d in subDirs)
                {
                    dirList.Add(d);
                    TraverseDir(d, dirList);
                }
            }
        }
    }
}
