
using System.Globalization;

var root = new Xmas.ElfFolder("/");
var currentDir = root;

// Process file
foreach (string line in System.IO.File.ReadLines(@"input.txt"))
{
    // Command: Line starts with $ == command

    if (line.StartsWith("$ cd", StringComparison.CurrentCulture))
    {
        // Change directory
        if (line == "$ cd /")
            currentDir = root;
        else if (line == "$ cd ..")
        {
            if (currentDir.Parent != null)
                currentDir = currentDir.Parent;
            else
                throw new InvalidDataException("Already root");
        }
        else
            currentDir = currentDir.GetSubFolder(line.Replace("$ cd ", ""));

    }

    // Non command lines

    // may be: dir <name>
    if (line.StartsWith("dir", StringComparison.CurrentCulture))
        currentDir.CreateDir(line.Replace("dir ", "", StringComparison.CurrentCulture));

    // file may be: <size> <name>
    if (char.IsDigit(line[0]))
    {
        var parts = line.Split(" ");
        currentDir.CreateFile(parts[1], int.Parse(parts[0], NumberStyles.Integer, CultureInfo.CurrentCulture));
    }
}

//Console.WriteLine(root.ToString());
Console.WriteLine($"SUM: {root.SumPrintPart1(0)}");
