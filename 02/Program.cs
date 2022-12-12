
var scoreMePart1 = 0;
var scoreMePart2 = 0;
var i = 0;

// Read file
foreach (string line in System.IO.File.ReadLines(@"input.txt"))
{
    i++;
    var move = line.Split(" ");
    var elveMove = move[0];
    var myMove = move[1];

    // decide who won // part 1
    scoreMePart1 += checkMove(0, move[0], move[1]);

    // decide who won // part 2
    scoreMePart2 += checkMove(1, move[0], move[1]);
}

Console.WriteLine($"Score: {scoreMePart1} - {scoreMePart2}");

// A for Rock, B for Paper, and C for Scissors
// X for Rock, Y for Paper, and Z for Scissors

// Score: (1 for Rock, 2 for Paper, and 3 for Scissors)
//        plus the score for the outcome of the round
//        (0 if you lost, 3 if the round was a draw, and 6 if you won)

int checkMove(int mode, string elf, string me)
{
    // Default: Elf wins
    var winner = 0;
    var origme = me;

    if (mode == 1)
        me = myStepPart2Is(elf, me);

    // Value my Card
    var value = 0;

    if (me == "X")
        value = 1;
    if (me == "Y")
        value = 2;
    if (me == "Z")
        value = 3;

    // Calculate winner score - Part 1

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

    // Calculate winner score - Part 2

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

    // Calculate winner score - Part 2
    // X means you need to lose, Y means you need to end the round in a draw, and Z means you need to win.


    // Debug
    if (mode == 0)
        Console.WriteLine($"{i:0000}: {mode} || {readableMove(elf)} - {readableMove(me)} || W:{winner} - V:{value} - S:{winner + value} - 1:{scoreMePart1 + winner + value}");
    else
        Console.WriteLine($"{i:0000}: {mode} || {readableMove(elf)} - {readableMove(me)} - O:{origme} || W:{winner} - V:{value} - S:{winner + value} - 1:{scoreMePart2 + winner + value}");

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

string myStepPart2Is(string elf, string me)
{
    // X means you need to lose
    // Y means you need to end the round in a draw
    // and Z means you need to win.

    // Draw
    if (me == "Y")
    {
        if (elf == "A")
            return "X";
        if (elf == "B")
            return "Y";
        if (elf == "C")
            return "Z";
    }

    // Loose
    if (me == "X")
    {
        if (elf == "A") // Rock - Looser must play Z (Scissors)
            return "Z";
        if (elf == "B") // Paper - Looser must play X (Rock)
            return "X";
        if (elf == "C") // Scissors - Looser must play Y (Paper)
            return "Y";
    }

    // Win
    if (me == "Z")
    {
        if (elf == "A") // Rock - Winner must play Y (Paper)
            return "Y";
        if (elf == "B") // Paper - Winner must play Z (Scissors)
            return "Z";
        if (elf == "C") // Scissors - Winner must play X (Rock)
            return "X";
    }

    return " ";
}
