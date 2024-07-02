using System.CommandLine;

class Program
{
    static async Task Main(string[] args)
    {
        var rootCommand = new RootCommand("Sample command-line app");
        rootCommand.SetHandler(() =>
        {
            Console.WriteLine("Hello world!");
            Console.ReadKey();
        });
        
        var subCommand1 = new Command("view", "View items");
        rootCommand.Add(subCommand1);

        var delayOption = new Option<int>
        (
            name: "--delay",
            description: "option argument passed as int",
            getDefaultValue: () => 42
        );

        subCommand1.Add(delayOption);
        subCommand1.SetHandler((delayOptionValue) =>
        {
            Console.WriteLine($"--delay = {delayOptionValue}");
        },delayOption);

        await rootCommand.InvokeAsync(args);


    }

}