using System;
using System.Collections.Generic;
using System.Linq;

namespace Day2;

public static class DecisionsMatrix
{
    private static readonly Dictionary<Tuple<char,char>, int> MatchScoresMatrix = new()
    {
        // Rock - A & X
        // Paper - B & Y
        // Scissors - C & Z
        { Tuple.Create('A', 'X'), 3 },
        { Tuple.Create('A', 'Y'), 6 },
        { Tuple.Create('A', 'Z'), 0 },
        { Tuple.Create('B', 'X'), 0 },
        { Tuple.Create('B', 'Y'), 3 },
        { Tuple.Create('B', 'Z'), 6 },
        { Tuple.Create('C', 'X'), 6 },
        { Tuple.Create('C', 'Y'), 0 },
        { Tuple.Create('C', 'Z'), 3 }
    };

    private static readonly Dictionary<Tuple<char,char>, char> OutcomeDecisionMatrix = new()
    {
        // Key (Tuple)
        // Rock: A, Paper: B, Scissors: C
        // Lose: X, Draw: Y, Win: Z
        // ----------------------------
        // Value
        // Rock: X, Paper: Y, Scissors: Z
        { Tuple.Create('A', 'X'), 'Z' },
        { Tuple.Create('A', 'Y'), 'X' },
        { Tuple.Create('A', 'Z'), 'Y' },
        { Tuple.Create('B', 'X'), 'X' },
        { Tuple.Create('B', 'Y'), 'Y' },
        { Tuple.Create('B', 'Z'), 'Z' },
        { Tuple.Create('C', 'X'), 'Y' },
        { Tuple.Create('C', 'Y'), 'Z' },
        { Tuple.Create('C', 'Z'), 'X' }
    };

    private static int GetChoiceScore(char rpsChoice)
    {
        return char.ToUpper(rpsChoice) switch
        {
            'X' => 1,
            'Y' => 2,
            'Z' => 3,
            _ => throw new ArgumentOutOfRangeException(nameof(rpsChoice), rpsChoice, "Invalid RPS choice")
        };
    }

    private static char GetChoiceRequiredToAchieveOutcome(char opponentChoice, char outcome)
    {
        return OutcomeDecisionMatrix[Tuple.Create(char.ToUpper(opponentChoice), char.ToUpper(outcome))];
    }

    public static int GetPartOneScore(char opponentChoice, char strategyChoice)
    {
        var key = Tuple.Create(char.ToUpper(opponentChoice), char.ToUpper(strategyChoice));
        return MatchScoresMatrix.First(x => x.Key.Equals(key)).Value + GetChoiceScore(strategyChoice);
    }

    public static int GetPartTwoScore(char opponentChoice, char outcomeChoice)
    {
        var rspChoiceToAchieveOutcome = GetChoiceRequiredToAchieveOutcome(opponentChoice, outcomeChoice);
        var key = Tuple.Create(char.ToUpper(opponentChoice), char.ToUpper(rspChoiceToAchieveOutcome));
        var matchScore = MatchScoresMatrix.First(x => x.Key.Equals(key)).Value;
        var choiceScore = GetChoiceScore(rspChoiceToAchieveOutcome);

        return matchScore + choiceScore;
    }
}
