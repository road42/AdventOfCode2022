using System.Collections;
using System.IO;

// Read File
var line = File.ReadLines(@"input.txt").First();

var search = new Queue<char>(5);
var charCounter = 0;

foreach (var c in line)
{
    search.Enqueue(c);
    charCounter++;

    if (search.Count == 5)
        search.Dequeue();

    var content = queueContentAsString(search);

    if (search.Count == 4)
    {
        var letters = content?
            .Distinct()
            .Count();

        if (letters == 4)
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
