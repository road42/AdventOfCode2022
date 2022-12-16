namespace Xmas
{
    public class ElfFile
    {
        public ElfFile(string Name, int Size)
        {
            this.Name = Name;
            this.Size = Size;
        }
        public string Name { get; set; } = string.Empty;
        public int Size { get; set; }

    }
}
