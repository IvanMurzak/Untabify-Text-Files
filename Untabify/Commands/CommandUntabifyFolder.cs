using UntabifyTextFiles.Console;
using UntabifyTextFiles.Console.Extensions;
using System;
using System.CommandLine;
using System.IO;

namespace UntabifyTextFiles.Commands;

public class CommandUntabifyFolder : CommandBase
{
    public CommandUntabifyFolder(string? description = null) : base("folder", description)
    {
        var argumentFolder          = new Argument<string>("folder", "Folder path");
        var optionFileSearchPattern = new Option<string>("fileSearchPattern", () => "*", "Filter files by search pattern. Example: '*.cs'.");
        var optionRecursively       = new Option<bool>("recursively", () => true, "Process files recursively in all subfolders");

        argumentFolder          .AddValidator(x => Directory.Exists(x.GetValueOrDefault<string>()));
        optionFileSearchPattern .AddAlias("s");
        optionRecursively       .AddAlias("r");


        this.FactoryAdd(argumentFolder)
            .FactoryAdd(optionFileSearchPattern)
            .FactoryAdd(optionRecursively)
            .FactorySetHandler(context =>
            {
                _logger.Info("[cyan]Untabify folder[/] command execution started");

                var tabSize = context.ParseResult.GetValueForOption(optionTabSize);
                var folderPath = context.ParseResult.GetValueForArgument(argumentFolder);

                var fileSearchPattern = context.ParseResult.GetValueForOption(optionFileSearchPattern);
                var recursively = context.ParseResult.GetValueForOption(optionRecursively);

                try
                {
                    TimeTracker.Do("Untabify folder",
                            () => Untabify.Processor.Untabify.ReplaceTabsInFolder
                            (
                                folderPath,
                                fileSearchPattern!,
                                tabSize,
                                recursively
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
