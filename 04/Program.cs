using System.Globalization;

var fullyCounter = 0;
var partCounter = 0;

// Read file
foreach (string line in System.IO.File.ReadLines(@"input.txt"))
{
    var cleanLine = line.Trim();
    var elfPairs = cleanLine.Split(',');

    var firstElfPairNumbers = elfPairs[0].Split('-');
    var firstElfFrom = int.Parse(firstElfPairNumbers[0], NumberStyles.Integer, CultureInfo.CurrentCulture);
    var firstElfTo = int.Parse(firstElfPairNumbers[1], NumberStyles.Integer, CultureInfo.CurrentCulture);

    var secondElfPairNumbers = elfPairs[1].Split('-');
    var secondElfFrom = int.Parse(secondElfPairNumbers[0], NumberStyles.Integer, CultureInfo.CurrentCulture);
    var secondElfTo = int.Parse(secondElfPairNumbers[1], NumberStyles.Integer, CultureInfo.CurrentCulture);

    int max = Math.Max(firstElfFrom, Math.Max(firstElfTo, Math.Max(secondElfFrom, secondElfTo)));

    // Create list with numbers from 1 to max
    int[] rangeList = Enumerable.Range(0, max + 1).ToArray();

    var firstElfRange = rangeList[firstElfFrom..(firstElfTo+1)];
    var secondElfRange = rangeList[secondElfFrom..(secondElfTo+1)];

    // Fully overlap checking
    // check if 1 is in 2
    var isFirstFullyInSecond = true;
    var isFirstPartInSecond = false;
    foreach (var c in firstElfRange)
    {
        // Fully check
        if (!secondElfRange.Contains(c))
            isFirstFullyInSecond = false;

        // part check
        if (secondElfRange.Contains(c))
            isFirstPartInSecond = true;
    }

    // check if 2 is in 1
    var isSecondFullyInFirst = true;
    var isSecondPartInFirst = false;
    foreach (var c in secondElfRange)
    {
        // Fully check
        if (!firstElfRange.Contains(c))
            isSecondFullyInFirst = false;

        // Part check
        if (firstElfRange.Contains(c))
            isSecondPartInFirst = true;
    }

    if (isFirstFullyInSecond || isSecondFullyInFirst )
        fullyCounter++;

    if (isFirstPartInSecond || isSecondPartInFirst )
        partCounter++;
}

Console.WriteLine($"Fully: {fullyCounter}");
Console.WriteLine($"Part:  {partCounter}");
