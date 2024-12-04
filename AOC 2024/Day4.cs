namespace AOC_2024;

public sealed class Day4 : AocTask {
    public override (object Part1, object Part2) Execute() {
        // Processing input
        string[] lines = Input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
        int r1 = 0, r2 = 0;

        // Part 1
        for (int y = 0; y < lines.Length; y++) {
            string line = lines[y];

            for (int x = 0; x < line.Length; x++) {
                if (line[x] is not 'X') continue;
                
                // Right and Left
                r1 += x + 3 < line.Length && line.AsSpan(x, 4) is "XMAS" ? 1 : 0;
                r1 += x - 3 >= 0 && line.AsSpan(x - 3, 4) is "SAMX" ? 1 : 0;
                
                // Downward and Upward
                r1 += y + 3 < lines.Length && lines[y + 1][x] is 'M' && lines[y + 2][x] is 'A' && lines[y + 3][x] is 'S' ? 1 : 0;
                r1 += y - 3 >= 0 && lines[y - 1][x] is 'M' && lines[y - 2][x] is 'A' && lines[y - 3][x] is 'S' ? 1 : 0;
                
                // Up-right and Downward-left
                r1 += y - 3 >= 0 && x + 3 < line.Length && lines[y - 1][x + 1] is 'M' && lines[y - 2][x + 2] is 'A' && lines[y - 3][x + 3] is 'S' ? 1 : 0;
                r1 += y + 3 < lines.Length && x - 3 >= 0 && lines[y + 1][x - 1] is 'M' && lines[y + 2][x - 2] is 'A' && lines[y + 3][x - 3] is 'S' ? 1 : 0;
                
                // Up-left and Downward-right
                r1 += y - 3 >= 0 && x - 3 >= 0 && lines[y - 1][x - 1] is 'M' && lines[y - 2][x - 2] is 'A' && lines[y - 3][x - 3] is 'S' ? 1 : 0;
                r1 += y + 3 < lines.Length && x + 3 < line.Length && lines[y + 1][x + 1] is 'M' && lines[y + 2][x + 2] is 'A' && lines[y + 3][x + 3] is 'S' ? 1 : 0;
            }
        }
        
        // Part 2
        for (int y = 1; y < lines.Length - 1; y++) {
            string line = lines[y];

            for (int x = 1; x < line.Length - 1; x++) {
                if (line[x] is not 'A') continue;

                bool stroke1 = lines[y - 1][x - 1] is 'M' && lines[y + 1][x + 1] is 'S' || lines[y - 1][x - 1] is 'S' && lines[y + 1][x + 1] is 'M';
                bool stroke2 = lines[y - 1][x + 1] is 'M' && lines[y + 1][x - 1] is 'S' || lines[y - 1][x + 1] is 'S' && lines[y + 1][x - 1] is 'M';

                if (stroke1 && stroke2) r2++;
            }
        }
        
        return (r1, r2);
    }
}