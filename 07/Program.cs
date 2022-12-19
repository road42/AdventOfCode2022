
using System.Globalization;
using System.Text.RegularExpressions;


// I struggled in part 2
// restart with port from https://pastebin.com/3TJs9GyR

var directories = new Stack<string>();
var size = new Dictionary<string, int>();

// Process file
foreach (string line in System.IO.File.ReadLines(@"input.txt"))
{
    // CD command
    if (line.StartsWith("$ cd", StringComparison.CurrentCulture))
    {
        var cdValue = line.Replace("$ cd ", "");

        if (cdValue == "/")
        {
            directories.Push(cdValue);
        }
        else if (cdValue == "..")
        {
            directories.Pop();
        }
        else
        {
            directories.Push(directories.First() + cdValue + "/" );
        }
    }
    // Filelisting
    else if (char.IsDigit(line[0]))
    {
        var fileSize = int.Parse(line.Split(" ")[0], NumberStyles.Integer, CultureInfo.CurrentCulture);

        foreach (var d in directories)
        {
            if (!size.ContainsKey(d))
            {
                size.Add(d, 0);
            }

            size[d] += fileSize;
        }
    }
}

// Sums
var totalSize = 70000000;
var occupiedSize = size.First().Value;
var threshold = 30000000 - (totalSize - occupiedSize);
var sizeUnder10000 = 0;
var foundSize = totalSize;

foreach (var s in size)
{
    // Part 1
    if (s.Value <= 100000)
        sizeUnder10000 += s.Value;

    // Part 2
    if (s.Value >= threshold && s.Value < foundSize)
    {
        foundSize = s.Value;
    }
}

Console.WriteLine($"Total:            {occupiedSize}");
Console.WriteLine($"Size under 10000: {sizeUnder10000}");
Console.WriteLine($"Foundsize:        {foundSize}");
