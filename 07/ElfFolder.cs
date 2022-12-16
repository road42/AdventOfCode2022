namespace Xmas
{
    public class ElfFolder
    {
        public ElfFolder() {}

        public ElfFolder(string Name)
        {
                this.Name = Name;
        }

        public ElfFolder(string Name, ElfFolder Parent)
        {
            this.Name = Name;
            this.Parent = Parent;
        }

        public string Name
        {
            get; private set;
        } = string.Empty;

        public ElfFolder? Parent
        {
            get; private set;
        }


        public void CreateDir(string Name)
        {
            if (!subdirectories.Any(f => f.Name == "Name"))
                subdirectories.Add(new ElfFolder(Name, this));
        }

        public void CreateFile(string Name, int Size)
        {
            if (!files.Any(f => f.Name == "Name"))
                files.Add(new ElfFile(Name, Size));
        }

        public ElfFolder GetSubFolder(string Name)
        {
            return subdirectories.First(f => f.Name == Name);
        }

        public int GetSize(bool recursive)
        {
            var value = 0;

            if (recursive)
                foreach (var f in subdirectories)
                    value += f.GetSize(recursive);

            value += files.Sum(f => f.Size);

            return value;
        }

        private List<ElfFolder> subdirectories = new List<ElfFolder>();
        private List<ElfFile> files = new List<ElfFile>();

        public override string ToString()
        {
            var ret = Name;

            ret += "\n Subdirectories: \n";

            foreach (var dir in subdirectories)
                ret += $"  - {dir.Name}\n";

            ret += "\n Files: \n";

            foreach (var file in files)
                ret += $"  - {file.Name}\t{file.Size}\n";

            ret += $"\n Size self: {this.GetSize(false)}\n";
            ret += $"\n Size tree: {this.GetSize(true)}\n";

            return ret;
        }

        public int SumPrintPart1(int lastSum)
        {
            var newSum = lastSum;
            var size = GetSize(true);

            if (size > 0 && size <= 100000)
                newSum += size;

            foreach (var f in subdirectories)
                newSum = f.SumPrintPart1(newSum);

            return newSum;
        }

    }
}
