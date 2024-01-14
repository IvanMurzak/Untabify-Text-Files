using UntabifyTextFiles.Console;
using UntabifyTextFiles.Console.Extensions;
using System;
using System.CommandLine;
using System.IO;

namespace UntabifyTextFiles.Commands;

public class CommandUntabifyFile : CommandBase
{
    public CommandUntabifyFile(string? description = null) : base("file", description)
    {
        var argumentFolder = new Argument<string>("file", "File path");
        argumentFolder.AddValidator(x => File.Exists(x.GetValueOrDefault<string>()));


        this.FactoryAdd(argumentFolder)
            .FactorySetHandler(context =>
            {
                _logger.Info("[cyan]Untabify folder[/] command execution started");

                var tabSize = context.ParseResult.GetValueForOption(optionTabSize);
                var filePath = context.ParseResult.GetValueForArgument(argumentFolder);

                try
                {
                    TimeTracker.Do("Untabify folder",
                            () => Untabify.Processor.Untabify.ReplaceTabsInFile
                            (
                                filePath,
                                tabSize
                            ))
                        .Print();
                }
                catch (Exception e)
                {
                    _logger.Error(e.Message);
                    context.ExitCode = 1;
                }
            });
    }
}
