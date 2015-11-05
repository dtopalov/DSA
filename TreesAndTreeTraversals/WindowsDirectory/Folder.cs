namespace WindowsDirectory
{
    using System.Collections.Generic;
    using System.Linq;

    public class Folder
    {
        public Folder(string name)
        {
            this.Name = name;
            this.Files = new List<File>();
            this.ChildFolders = new List<Folder>();
        }

        public string Name { get; set; }
        public Folder ParentFolder { get; set; }
        public IList<File> Files { get; set; }
        public IList<Folder> ChildFolders { get; set; }

        public long Size()
        {
            return this.Files.Sum(file => file.Size) + this.ChildFolders.Sum(folder => folder.Size());
        }
    }
}
