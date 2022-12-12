using System.Globalization;
using Xmas;

var readings = new List<Elf>();
var i = 1;
var value = 0;

// Read file
foreach (string line in System.IO.File.ReadLines(@"input.txt"))
{
    if (!string.IsNullOrEmpty(line))
    {
        value += int.Parse(line, CultureInfo.InvariantCulture);
    }
    else
    {
        i++;
        readings.Add(new Elf() { Number = i, Calories = value });
        value = 0;
    }
}

// Output
var top3 = readings
            .OrderByDescending(c => c.Calories)
            .Take(3);

var sumTop3 = top3.Sum(c => c.Calories);

foreach (var e in top3)
{
    Console.WriteLine($"{e.Number}, {e.Calories}");
}

Console.WriteLine(sumTop3);
