namespace AOC_2024;

public sealed class Day5 : AocTask {
    public override (object Part1, object Part2) Execute() {
        // Processing input
        List<(int Left, int Right)> rules = [];
        List<int[]> updates = [];

        string[] sections = Input.Split($"{Environment.NewLine}{Environment.NewLine}");

        foreach (var line in sections[0].Split(Environment.NewLine)) {
            int[] numbers = line.Split('|').Select(int.Parse).ToArray();
            
            rules.Add((numbers[0], numbers[1]));
        }

        foreach (var line in sections[1].Split(Environment.NewLine)) {
            updates.Add(line.Split(',').Select(int.Parse).ToArray());
        }

        int r1 = 0, r2 = 0;
        
        // Part 1
        foreach (var update in updates) {
            if (!IsRightOrder(update, rules)) continue;
            
            r1 += update[update.Length / 2];
        }
        
        // Part 2
        foreach (var update in updates) {
            if (IsRightOrder(update, rules)) continue;

            int[] buffer = new int[update.Length];
            update.CopyTo(buffer, 0);

            Array.Sort(update, ReorderComparison);
            
            r2 += update[update.Length / 2];
        }

        return (r1, r2);

        int ReorderComparison(int x, int y) {
            return rules.Contains((x, y)) ? -1 : rules.Contains((y, x)) ? 1 : 0;
        }
    }

    private static bool IsRightOrder(ReadOnlySpan<int> numbers, List<(int Left, int Right)> rules) {
        for (var i = numbers.Length - 1; i > 0; i--) {
            for (var j = i - 1; j >= 0; j--) {
                if (rules.Contains((numbers[i], numbers[j]))) {
                    return false;
                }
            }
        }

        return true;
    }
}