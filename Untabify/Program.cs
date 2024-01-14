using System;
using System.CommandLine;
using System.CommandLine.Parsing;
using Spectre.Console;
using NLog;
using UntabifyTextFiles.Console;
using UntabifyTextFiles.Commands;
using UntabifyTextFiles.Console.Extensions;
using System.Threading.Tasks;

class Program
{
    private static readonly ILogger _logger = LogManager.GetCurrentClassLogger();

    [STAThread]
    static void Main(string[] args)
    {
        UNConsole.ULogo();

        var rootCommand = BuildCommands();

        if (args.Length == 0) // console mode
        {
            _logger.Info("Use [cyan]-h[/] or [cyan]--help[/] command to see all available commands");
            while (true)
            {
                AnsiConsole.Markup("[red] > [/]");

                var commandLine = Console.ReadLine();
                if (string.IsNullOrEmpty(commandLine))
                {
                    AnsiConsole.MarkupLine("[red] Wrong command, abort. [/]");
                    continue;
                }

                if (commandLine.StartsWith(".\\"))
                    commandLine = commandLine.Substring(2);
                if (commandLine.StartsWith("./"))
                    commandLine = commandLine.Substring(2);
                if (commandLine.ToLower().StartsWith("eve-master.exe"))
                    commandLine = commandLine.Substring(14);
                if (commandLine.ToLower().StartsWith("eve-master"))
                    commandLine = commandLine.Substring(10);

                Task.Run(() => InvokeCommand
                (
                    () => rootCommand.InvokeAsync(commandLine),
                    exit: false
                )).Wait();
            }
        }
        else // single command execution mode
        {
            Task.Run(() => InvokeCommand
            (
                () => rootCommand.InvokeAsync(args),
                exit: true
            )).Wait();
        }
    }
    static RootCommand BuildCommands()
    {
        return (RootCommand)new RootCommand("Metrics Analyzer tool.")
            .FactoryAdd(new CommandUntabifyFolder("Process local .csv files"));
    }
    static async Task InvokeCommand(Func<Task<int>> invoke, bool exit = true)
    {
        try
        {
            var result = await invoke();
            if (result == 0)
            {
                UNConsole.OperationCompleted("Finished successfully");
            }
            else
            {
                _logger.Fatal($"finished with error result = {result}", true);
            }
            if (exit) Environment.Exit(result);
        }
        catch (Exception e)
        {
            _logger.Fatal(e);
            if (exit) Environment.Exit(1);
        }
    }
}