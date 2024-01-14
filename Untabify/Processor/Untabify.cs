using NLog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Untabify.Processor;

static internal class Untabify
{
    private static readonly ILogger _logger = LogManager.GetCurrentClassLogger();

    public static int ReplaceTabsInFolder(string folder, string fileSearchPattern, int tabSize, bool recursively)
    {
        var filePaths = Directory.GetFiles(folder, fileSearchPattern, recursively 
            ? SearchOption.AllDirectories 
            : SearchOption.TopDirectoryOnly);

        var changedCounter = 0;
        foreach (var filePath in filePaths)
        {
            if (ReplaceTabsInFile(filePath, tabSize))
                changedCounter++;
        }
        return changedCounter;
    }
    public static bool ReplaceTabsInFile(string filePath, int tabSize)
    {
        var lines = File.ReadAllLines(filePath);
        var changed = false;

        for (var i = 0; i < lines.Length; i++)
        {
            var line = lines[i];
            if (ReplaceTabs(ref line, tabSize))
            {
                changed = true;
                lines[i] = line;
            }
        }

        if (changed)
        {
            _logger.Info($"[green]untabified[/] {filePath}");
            File.WriteAllLines(filePath, lines, Encoding.UTF8);
        }
        return changed;
    }
    public static bool ReplaceTabs(ref string line, int tabSize)
    {
        var changed = false;
        for (int i = 0; i < line.Length; i++)
        {
            if (line[i] == '\t')
            {
                changed = true;
                line = line.Remove(i, 1);
                line = line.Insert(i, new string(' ', tabSize - i % tabSize));
            }
        }
        return changed;
    }

}
