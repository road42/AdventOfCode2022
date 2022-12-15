using System.Globalization;

var fullyCounter = 0;

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

    var numberList = new List<int>();
    numberList.Add(firstElfFrom);
    numberList.Add(firstElfTo);
    numberList.Add(secondElfFrom);
    numberList.Add(secondElfTo);

    // Create list with numbers from 1 to max
    int[] rangeList = Enumerable.Range(0, numberList.Max() + 1).ToArray();

    var firstElfRange = rangeList[firstElfFrom..(firstElfTo+1)];
    var secondElfRange = rangeList[secondElfFrom..(secondElfTo+1)];

    // check if 1 is in 2
    var isFirstFullyInSecond = true;
    foreach (var c in firstElfRange)
    {
        if (!secondElfRange.Contains(c))
            isFirstFullyInSecond = false;
    }

    // check if 2 is in 1
    var isSecondFullyInFirst = true;
    foreach (var c in secondElfRange)
    {
        if (!firstElfRange.Contains(c))
            isSecondFullyInFirst = false;
    }

    if (isFirstFullyInSecond || isSecondFullyInFirst )
        fullyCounter++;

    Console.WriteLine($"{cleanLine}: {firstElfRange.First()}-{firstElfRange.Last()},{secondElfRange.First()}-{secondElfRange.Last()} ... ?:{isFirstFullyInSecond}|{isSecondFullyInFirst}");

}

Console.WriteLine(fullyCounter);
