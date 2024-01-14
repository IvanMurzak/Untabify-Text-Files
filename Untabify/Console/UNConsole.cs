using NLog;
using NLog.Config;
using Spectre.Console;
using System.Threading.Tasks;

namespace UntabifyTextFiles.Console;

static internal class UNConsole
{
    public const string ColorOperationSuccess = "[mediumspringgreen]{0}[/]"; // mediumspringgreen, deepskyblue1
    public const string ColorOperationFailed = "[orangered1]{0}[/]";

    private static readonly ILogger _logger = LogManager.GetCurrentClassLogger();
    public static void OperationCompleted(string message, bool success = true)
    {
        if (success)
        {
            _logger.Info(string.Format(ColorOperationSuccess, message));
            _logger.Info("----------------------------");
        }
        else
        {
            _logger.Warn(string.Format(ColorOperationFailed, message));
            _logger.Warn("----------------------------");
        }
    }
    public static void OperationCompleted(Task<string> task, bool success = true)
    {
        var message = task.GetAwaiter().GetResult();
        OperationCompleted(message, success);
    }
    public static void ULogo()
    {
        AnsiConsole.Write(new FigletText($"Untabify")
            .LeftJustified()
            .Color(Color.DarkSeaGreen2));
    }

    static UNConsole()
    {
        var config = new LoggingConfiguration();

        AddConsoleOutput(config, LogLevel.Info,  "[grey19]${date:format=HH\\:mm\\:ss}[/] [grey27]INFO[/]  ${message}");
        AddConsoleOutput(config, LogLevel.Warn,  "[grey19]${date:format=HH\\:mm\\:ss}[/] [orangered1]WARN[/]  ${message}");
        AddConsoleOutput(config, LogLevel.Error, "[grey19]${date:format=HH\\:mm\\:ss}[/] [maroon]ERROR[/] ${message}");
        AddConsoleOutput(config, LogLevel.Fatal, "[grey19]${date:format=HH\\:mm\\:ss}[/] [red1]FATAL[/] [grey19]${loggername}[/] ${message}");

        LogManager.Configuration = config;
    }
    private static void AddConsoleOutput(LoggingConfiguration config, LogLevel logLevel, string layout)
    {
        var info = new LogConsoleTarget
        {
            Name = "console",
            Layout = layout
        };
        config.AddTarget(info);
        config.AddRule(logLevel, logLevel, info, $"*");
    }
}
