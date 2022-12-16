using System;
using System.IO;
using Day2;

//var inputLines = File.ReadLines("../../../day2_input_small.txt");
var inputLines = File.ReadLines("../../../day2_input.txt");

var total = 0;

foreach (var line in inputLines)
{
    var parts = line.Split(' ');
    var opponentChoice = parts[0][0];
    var strategicChoice = parts[1][0];

    // Part 1
    //total += DecisionsMatrix.GetPartOneScore(opponentChoice, strategicChoice);

    // Part 2
    total += DecisionsMatrix.GetPartTwoScore(opponentChoice, strategicChoice);
}

Console.WriteLine(total);
Console.ReadLine();
