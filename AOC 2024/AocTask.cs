namespace AOC_2024;

public abstract class AocTask {
    protected string Input { get; }
    protected string? ExampleInput { get; }
    
    protected AocTask() {
        Input = File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", $"{GetType().Name}.txt"));

        string exampleInputFile = Path.Combine(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", $"{GetType().Name}_Ex.txt"));
        if (File.Exists(exampleInputFile)) {
            ExampleInput = File.ReadAllText(exampleInputFile);
        }
    }
    
    public abstract (object Part1, object Part2) Execute();
}