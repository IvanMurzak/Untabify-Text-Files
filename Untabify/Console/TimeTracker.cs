using System;
using System.Threading.Tasks;

namespace UntabifyTextFiles.Console;

public static class TimeTracker
{
    public static TimeTrackData Do(string message, Action action)
    {
        var stopwatch = new System.Diagnostics.Stopwatch(); 
        stopwatch.Start();
        
        action.Invoke();

        stopwatch.Stop();
        return new TimeTrackData($"{message} {stopwatch.ElapsedMilliseconds}ms");
    }
    public static TimeTrackData<T> Do<T>(string message, Func<T> func)
    {
        var stopwatch = new System.Diagnostics.Stopwatch();
        stopwatch.Start();

        var taskResult = func.Invoke();

        stopwatch.Stop();
        return new TimeTrackData<T>(taskResult, $"{message} {stopwatch.ElapsedMilliseconds}ms");
    }
    public static TimeTrackData<T> DoTask<T>(string message, Func<Task<T>> func)
    {
        var stopwatch = new System.Diagnostics.Stopwatch();
        stopwatch.Start();

        var taskResult = func.Invoke().GetAwaiter().GetResult();

        stopwatch.Stop();
        return new TimeTrackData<T>(taskResult, $"{message} {stopwatch.ElapsedMilliseconds}ms");
    }
    public static TimeTrackData<T> Do<T>(string message, Task<T> task)
    {
        var stopwatch = new System.Diagnostics.Stopwatch();
        stopwatch.Start();

        var taskResult = task.GetAwaiter().GetResult();

        stopwatch.Stop();
        return new TimeTrackData<T>(taskResult, $"{message} {stopwatch.ElapsedMilliseconds}ms");
    }
}
public class TimeTrackData<T>
{
    public T Result { get; private set; }
    public string Message { get; private set; }

    public TimeTrackData(T result, string message)
    {
        Result = result;
        Message = message;
    }
}
    public class TimeTrackData
    {
        public string Message { get; private set; }

        public TimeTrackData(string message)
        {
            Message = message;
        }
    }
