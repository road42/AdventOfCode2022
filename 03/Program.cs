
var sumOfItems = 0;

// Read file
foreach (string line in System.IO.File.ReadLines(@"input.txt"))
{
    var cleanLine = line.Trim();

    var amountOfItems = cleanLine.Length;
    var firstHalf = cleanLine.Substring(0, amountOfItems / 2);
    var secondHalf = cleanLine.Substring(amountOfItems / 2);

    var foundDouble = "";

    // Get shared items
    foreach(var c in firstHalf)
    {
        if (secondHalf.Contains(c) && !foundDouble.Contains(c))
            foundDouble += c;
    }

    var value = 0;
    var asciiValue = (int) foundDouble.ToCharArray()[0];

    // lower case
    if (asciiValue >= 97 && asciiValue <= 122)
    {
        value = asciiValue - 96;
    }

    // uppercase
    if (asciiValue >= 65 && asciiValue <= 90)
    {
        value = asciiValue - 64 + 26;
    }

    sumOfItems += value;
}

Console.WriteLine($"Sum: {sumOfItems}");
