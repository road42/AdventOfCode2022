
var readings = new List<Elf>();
var i = 1;
var value = 0;

// Read file
foreach (string line in System.IO.File.ReadLines(@"input.txt"))
{
    if (!string.IsNullOrEmpty(line))
    {
        value += int.Parse(line);
    }
    else
    {
        i++;
        readings.Add(new Elf() { Number = i, Calories = value });
        value = 0;
    }
}

// Output
var top10 = readings
            .OrderByDescending(c => c.Calories)
            .Take(10);

foreach (var e in top10)
{
    Console.WriteLine($"{e.Number}, {e.Calories}");
}