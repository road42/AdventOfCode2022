﻿using System.Globalization;

// Initialize Stacks read all stack-lines
var stackLines = new List<string>();
var readStackLines = true;

var instructionLines = new List<string>();

// Read file
foreach (string line in System.IO.File.ReadLines(@"input.txt"))
{
    // Read the startup lines first
    if (readStackLines)
    {
        if (string.IsNullOrWhiteSpace(line) && readStackLines == true)
            readStackLines = false;
        else
        {
            stackLines.Add(line + " ");
        }
    }
    else
    {
        if (!string.IsNullOrWhiteSpace(line))
            instructionLines.Add(line);
    }
}

var stacks = new Dictionary<int, LinkedList<string>>();

// Initialize stack array

// last line should contain the amount of stacks
var tmpLine = stackLines
                .Last()
                .Trim()
                .Reverse()
                .ToArray();

var number = "";
// get the last number from stackline
for (var i = 0; i<tmpLine.Length; i++)
{
    if (tmpLine[i] == ' ')
        break;

    number += tmpLine[i];
}

var amountOfStacks = int.Parse(number, NumberStyles.Integer, CultureInfo.CurrentCulture);

for (var i = 0; i < amountOfStacks; i++)
{
    stacks.Add(i, new LinkedList<string>());
}

// fill crates to stackarray
for (var i = stackLines.Count - 2; i >= 0; i--)
{
    // get the amount of stackpositions in line
    var amountPositions = (stackLines[i].Length) / 4;

    for (var j = 0; j < amountPositions; j++)
    {
        var stackEntry = stackLines[i].Substring(j*4, 4);

        // Clean data
        stackEntry = stackEntry
            .Replace("[", "")
            .Replace("]", "")
            .Trim();

        if (!string.IsNullOrEmpty(stackEntry))
            stacks[j].AddLast(stackEntry);
    }
}

void stacksOutput()
{
    foreach (var s in stacks)
    {
        Console.Write($"S:{s.Key+1} - ");

        foreach (var e in s.Value)
        {
            Console.Write($"{e}");
        }

        Console.WriteLine();
    }

    Console.WriteLine();
    foreach (var s in stacks)
    {
        if (s.Value.Count > 0)
            Console.Write($"Message: {s.Value.Last()}");
    }

    Console.WriteLine();
}

// Do moves
foreach (var m in instructionLines)
{
    // 0    1 2    3 4  5
    // move 2 from 8 to 2
    var instructions = m.Split(" ");

    var moveAmount = int.Parse(instructions[1], NumberStyles.Integer, CultureInfo.CurrentCulture);
    var fromStackNumber = int.Parse(instructions[3], NumberStyles.Integer, CultureInfo.CurrentCulture);
    var toStackNumber = int.Parse(instructions[5], NumberStyles.Integer, CultureInfo.CurrentCulture);

    for (var i = 0; i < moveAmount; i++)
    {
        var element = stacks[fromStackNumber - 1].Last();
        stacks[fromStackNumber - 1].RemoveLast();
        stacks[toStackNumber - 1].AddLast(element);
    }
}

stacksOutput();

