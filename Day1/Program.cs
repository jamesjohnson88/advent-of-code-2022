using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

var inputLines = File.ReadLines("../../../day1_input.txt");
//var inputLines = File.ReadLines("../../../day1_input_small.txt");

var elfInventories = new Dictionary<int, List<int>>();
var elfIndex = 1;
var lastLineWasBlank = true;

foreach (var line in inputLines)
{
    if (string.IsNullOrWhiteSpace(line) || !int.TryParse(line, out var lineValue))
    {
        if (!lastLineWasBlank)
        {
            elfIndex++;
        }

        lastLineWasBlank = true;
        continue;
    }

    if (elfInventories.ContainsKey(elfIndex))
    {
        elfInventories[elfIndex].Add(lineValue);
    }
    else
    {
        elfInventories.Add(elfIndex, new List<int> { lineValue });
    }

    lastLineWasBlank = false;
}

var totals = elfInventories.Select(x => x.Value.Sum()).OrderByDescending(x => x).ToList();

// Part 1 Answer
Console.WriteLine(totals.First());

// Part 2 Answer
Console.WriteLine(totals.Take(3).Sum());

Console.ReadLine();
