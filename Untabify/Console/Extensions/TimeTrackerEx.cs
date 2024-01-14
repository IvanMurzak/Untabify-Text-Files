namespace UntabifyTextFiles.Console.Extensions;

internal static class TimeTrackerEx
{
    public static TimeTrackData Print(this TimeTrackData trackerData, bool success = true)
    {
        UNConsole.OperationCompleted(trackerData.Message, success);
        return trackerData;
    }
    public static TimeTrackData<T> Print<T>(this TimeTrackData<T> trackerData, bool success = true)
    {
        UNConsole.OperationCompleted(trackerData.Message, success);
        return trackerData;
    }
    public static TimeTrackData<T> PrintSuccessIfNotNull<T>(this TimeTrackData<T> trackerData)
    {
        return trackerData.Print(trackerData.Result != null);
    }
    public static TimeTrackData<bool> PrintSuccessIfTrue(this TimeTrackData<bool> trackerData)
    {
        return trackerData.Print(trackerData.Result);
    }
}
