using System;
using Spectre.Console;
using NLog;
using NLog.Config;
using NLog.Targets;

namespace UntabifyTextFiles.Console;

[Target("SpectreConsole")]
internal class LogConsoleTarget : TargetWithLayout
{
    public LogConsoleTarget()
    {
        Host = "localhost";
    }

    [RequiredParameter]
    public string Host { get; set; }

    protected override void Write(LogEventInfo logEvent)
    {
        string logMessage = RenderLogEvent(Layout, logEvent);
        string hostName = RenderLogEvent(Host, logEvent);
        SendTheMessageToRemoteHost(hostName, logMessage);
    }

    private void SendTheMessageToRemoteHost(string hostName, string message)
    {
        try
        {
            AnsiConsole.MarkupLine(message);
        }
        catch (Exception e)
        {
            System.Console.WriteLine(e);
            System.Console.WriteLine(message);
        }
    }
}
