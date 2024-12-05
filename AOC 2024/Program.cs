using AOC_2024;
using System.Reflection;

Type[] dayTasks = Assembly.GetExecutingAssembly().GetTypes().Where(x => x.IsSubclassOf(typeof(AocTask))).ToArray();

Console.WriteLine("Hello, World!");

Type? taskType;

while (true) {
    Console.Write("Input day: ");
    
    if (!int.TryParse(Console.ReadLine(), out int day) || day <= 0) {
        Console.WriteLine("Invalid day! Input must be an positive integer!");
        continue;
    }

    taskType = dayTasks.FirstOrDefault(x => x.Name == $"Day{day}");

    if (taskType != null) {
        break;
    }

    Console.WriteLine("Invalid day! Cannot find AocTask type associate with the day!");
}

AocTask task = (AocTask)Activator.CreateInstance(taskType)!;
(object p1, object p2) = task.Execute();

Console.WriteLine($"Results: {p1}, {p2}");