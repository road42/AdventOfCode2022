using System.Collections;
using System.IO;

// Read File
var line = File.ReadLines(@"input.txt").First();

// Part 2
var amountOfCharsNeeded = 14;

var search = new Queue<char>(amountOfCharsNeeded+1);
var charCounter = 0;

foreach (var c in line)
{
    search.Enqueue(c);
    charCounter++;

    if (search.Count == amountOfCharsNeeded+1)
        search.Dequeue();

    var content = queueContentAsString(search);

    if (search.Count == amountOfCharsNeeded)
    {
        var letters = content?
            .Distinct()
            .Count();

        if (letters == amountOfCharsNeeded)
        {
            Console.WriteLine($"Found@ {charCounter} - Q: {content}");
            break;
        }
    }
}

string queueContentAsString(IEnumerable<char> search)
{
    var ret = "";

    foreach (var c in search)
        ret += c;

    return ret;
}
