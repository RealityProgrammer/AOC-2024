namespace AOC_2024;

public sealed class Day1 : AocTask {
    public override (object Part1, object Part2) Execute() {
        // Processing input
        List<int> left = [], right = [];
        
        foreach (var line in Input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries)) {
            string[] numbers = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            
            left.Add(int.Parse(numbers[0]));
            right.Add(int.Parse(numbers[1]));
        }
        
        left.Sort();
        right.Sort();

        ulong r1 = 0, r2 = 0;
        
        // Part 1
        foreach ((int lhs, int rhs) in left.Zip(right)) {
            r1 += (ulong)long.Abs(lhs - rhs);
        }
        
        // Part 2
        foreach (var number in left) {
            int appear = right.Count(x => x == number);

            r2 += (ulong)number * (ulong)appear;
        }
        
        return (r1, r2);
    }
}