using NLog;
using System;
using System.CommandLine;

namespace UntabifyTextFiles.Commands;

public class CommandBase : Command, IDisposable
{
    protected static readonly ILogger _logger = LogManager.GetCurrentClassLogger();

    protected Option<int> optionTabSize = new Option<int>("tab-size", () => 4, "Tab size in space characters.");
    public CommandBase(string name, string? description = null) : base(name, description)
    {
        optionTabSize.AddAlias("t");
        optionTabSize.AddAlias("t");

        AddGlobalOption(optionTabSize);
    }

    public void Dispose()
    {
    }
}
