namespace AOC_2024;

public sealed class Day2 : AocTask {
    public override (object Part1, object Part2) Execute() {
        // Processing input
        List<int[]> reports = [];
        foreach (var line in Input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries)) {
            reports.Add(line.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray());
        }
        
        List<int[]> unsafeReports = [];
        int r1 = 0, r2 = 0;
        
        // Part 1
        foreach (var report in reports) {
            if (IsReportSafe(report)) {
                r1++;
            } else {
                unsafeReports.Add(report);
            }
        }
        
        // Part 2
        r2 = r1;
        foreach (var report in unsafeReports) {
            for (int i = 0; i < report.Length; i++) {
                List<int> adjustedReport = report.ToList();
                adjustedReport.RemoveAt(i);
                
                if (IsReportSafe(adjustedReport)) {
                    r2++;
                    break;
                }
            }
        }

        return (r1, r2);
    }

    private static bool IsReportSafe(IReadOnlyList<int> report) {
        int lastDiff = report[1] - report[0];

        if (int.Abs(lastDiff) is < 1 or > 3) return false;
            
        for (int i = 1; i < report.Count; i++) {
            int diff = report[i] - report[i - 1];

            if (int.Sign(lastDiff) != int.Sign(diff) || int.Abs(diff) is < 1 or > 3) {
                return false;
            }

            lastDiff = diff;
        }

        return true;
    }
}