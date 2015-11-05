namespace WindowsDirectory
{
    public class File
    {
        public string Name { get; set; }
        public long Size { get; set; }
        public Folder ParentFolder { get; set; }
    }
}
