
var sumOfItems = 0;
var sumOfGroups = 0;

var groupCounter = 0;
var group = new List<string>();

// Read file
foreach (string line in System.IO.File.ReadLines(@"input.txt"))
{
    var cleanLine = line.Trim();

    var amountOfItems = cleanLine.Length;
    var firstHalf = cleanLine.Substring(0, amountOfItems / 2);
    var secondHalf = cleanLine.Substring(amountOfItems / 2);

    groupCounter++;

    // add line to elfGroupList
    if (groupCounter <= 3)
        group.Add(cleanLine);

    var foundDouble = "";

    // Get shared items (part 1)
    foreach (var c in firstHalf)
    {
        if (secondHalf.Contains(c) && !foundDouble.Contains(c))
            foundDouble += c;
    }

    // Get shared items (part 2)
    if (groupCounter == 3)
    {
        var foundDouble2 = "";

        // compare 1 to 2/3
        foreach (var c in group[0])
            if (group[1].Contains(c) && group[2].Contains(c) && !foundDouble2.Contains(c))
                foundDouble2 += c;

        // compare 2 to 3
        foreach (var c in group[1])
            if (group[0].Contains(c) && group[2].Contains(c) && !foundDouble2.Contains(c))
                foundDouble2 += c;

        foreach (var l in group)
            Console.WriteLine($"L: {l}");

        Console.WriteLine($"D: {foundDouble2}");
        Console.WriteLine(".......................................");

        sumOfGroups += getValueForChar(foundDouble2.ToCharArray()[0]);
        groupCounter = 0;
        group.Clear();
    }

    sumOfItems += getValueForChar(foundDouble.ToCharArray()[0]);
}

int getValueForChar(char c)
{
    var asciiValue = (int)c;

    // lower case
    if (asciiValue >= 97 && asciiValue <= 122)
    {
        return asciiValue - 96;
    }

    // uppercase
    if (asciiValue >= 65 && asciiValue <= 90)
    {
        return asciiValue - 64 + 26;
    }

    return 0;
}

Console.WriteLine($"SumItems: {sumOfItems}");
Console.WriteLine($"SumGroups: {sumOfGroups}");
