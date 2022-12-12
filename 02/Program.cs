
var scoreMe = 0;
var i = 0;

// Read file
foreach (string line in System.IO.File.ReadLines(@"input.txt"))
{
    i++;
    var move = line.Split(" ");
    var elveMove = move[0];
    var myMove = move[1];

    // decide who won
    scoreMe += checkMove(move[0], move[1]);
}

Console.WriteLine($"Score: {scoreMe}");

// A for Rock, B for Paper, and C for Scissors
// X for Rock, Y for Paper, and Z for Scissors

// Score: (1 for Rock, 2 for Paper, and 3 for Scissors)
//        plus the score for the outcome of the round
//        (0 if you lost, 3 if the round was a draw, and 6 if you won)

int checkMove(string elf, string me)
{
    // Default: Elf wins
    var winner = 0;

    // Value my Card
    var value = 0;

    if (me == "X")
        value = 1;
    if (me == "Y")
        value = 2;
    if (me == "Z")
        value = 3;

    // Calculate winner score

    // Draw?
    if (
           (elf == "A" && me == "X")   // Draw must play X (Rock)
        || (elf == "B" && me == "Y")   // Draw must play Y (Paper)
        || (elf == "C" && me == "Z")   // Draw must play X (Scissors)
    )
    {
        winner = 3;
    }
    else if (
           (elf == "A" && me == "Y")   // Winner must play Y (Paper)
        || (elf == "B" && me == "Z")   // Winner must play Z (Scissors)
        || (elf == "C" && me == "X")   // Winner must play X (Rock)
    )
    {
        winner = 6;
    }

    // Debug
    Console.WriteLine($"{i:0000}: {readableMove(elf)} - {readableMove(me)} || W:{winner} - V:{value} - S:{winner+value} - A:{scoreMe+winner+value}");

    return winner + value;
}

string readableMove(string move)
{
    if (move == "A" || move == "X")
        return "Rock    ";

    if (move == "B" || move == "Y")
        return "Paper   ";

    return "Scissors";
}
