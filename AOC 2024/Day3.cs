using System.Text.RegularExpressions;

namespace AOC_2024;

public sealed partial class Day3 : AocTask {
    public override (object Part1, object Part2) Execute() {
        // Processing input
        MatchCollection matches = MultiplicationRegex.Matches(Input);
        ulong r1 = 0, r2 = 0;
        
        // Part 1
        foreach (Match match in matches) {
            if (match.ValueSpan.StartsWith("mul")) {
                int[] numbers = match.ValueSpan[4..^1].ToString().Split(',').Select(int.Parse).ToArray();
                r1 += (ulong)(numbers[0] * numbers[1]);
            }
        }
        
        // Part 2
        bool enable = true;

        foreach (Match match in matches) {
            if (match.ValueSpan.StartsWith("mul") && enable) {
                int[] numbers = match.ValueSpan[4..^1].ToString().Split(',').Select(int.Parse).ToArray();
                r2 += (ulong)(numbers[0] * numbers[1]);
            }

            if (match.ValueSpan.StartsWith("don't")) {
                enable = false;
            } else if (match.ValueSpan.StartsWith("do")) {
                enable = true;
            }
        }
        
        return (r1, r2);
    }

    [GeneratedRegex(@"mul\(\d+,\d+\)|do\(\)|don't\(\)")]
    private static partial Regex MultiplicationRegex { get; }
}