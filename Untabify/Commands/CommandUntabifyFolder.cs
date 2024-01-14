using UntabifyTextFiles.Console;
using UntabifyTextFiles.Console.Extensions;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.CommandLine;
using System.IO;

namespace UntabifyTextFiles.Commands;

public class CommandUntabifyFolder : CommandBase
{
    public CommandUntabifyFolder(string? description = null) : base("folder", description)
    {
        var argumentCompaniesFile = new Argument<string>("companies", "File name of companies (without extension).");
        var argumentMetricsFile = new Argument<string>("metrics", "File name of metrics (without extension).");
        var optionOutput = new Option<string>("output", () => "app-credit-risk-ratings", "File name for printing result (without extension).");

        this.FactoryAdd(argumentCompaniesFile)
            .FactoryAdd(argumentMetricsFile)
            .FactoryAdd(optionOutput)
            .FactorySetHandler(context =>
            {
                _logger.Info("[cyan]Analyze[/] command execution started");

                var fileNameCompanies = context.ParseResult.GetValueForArgument(argumentCompaniesFile);
                var fileNameMetrics = context.ParseResult.GetValueForArgument(argumentMetricsFile);
                var fileOutput = context.ParseResult.GetValueForOption(optionOutput);

                try
                {
                    //TimeTracker.Do("Console printing data",
                    //        () => ConsolePrint(result))
                    //    .Print();

                    //TimeTracker.Do("Produce CSV file",
                    //        () => ProduceCSVFile(result, fileOutput!))
                    //    .Print();
                }
                catch (Exception e)
                {
                    _logger.Error(e.Message);
                    context.ExitCode = 1;
                }
            });
    }
}
