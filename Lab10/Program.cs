// Lab 10
// Student name: Jasmine Wang
// Student number: 12140943

using System;
using System.Collections.Generic;

Console.WriteLine("CPEN223 Lab 10");

//Testing: Write some test cases to test well all methods you are to implement
//         This is to demonstrates what test cases you have considered
var data = new List<Sample>
{
    new("A", 4, 8),
    new("B", 2, 4),
    new("A", 0, 6),
    new("A", 5, 9)
};

var result = WindowSelector.SelectWindow(data, "A", 0, 5);

foreach (Sample s in result)
{
    Console.WriteLine($"{s.Sensor} {s.Minute} {s.Value}");
}
//end Testing code

//Do not change the program skeleton: keep the record structs, the class name,
//method names, parameters, and return types exactly as given.
//You may add private helper methods.

public readonly record struct Sample(
    string Sensor,
    int Minute,
    double Value);

public static class WindowSelector
{
    /// <summary>
    /// Selects records for one sensor in a half-open time window.
    /// </summary>
    /// <param name="samples">
    /// Non-null. Each Sample.Sensor is non-null and each Value is
    /// finite. Minute is measured in integer minutes since the
    /// beginning of the fictional session.
    /// </param>
    /// <param name="sensor">Non-null, nonempty sensor name.</param>
    /// <param name="startInclusive">Inclusive start (minutes).</param>
    /// <param name="endExclusive">
    /// Exclusive end (minutes); at least startInclusive.
    /// </param>
    /// <returns>
    /// A new list of Sample records with matching Sensor (ordinal,
    /// case-sensitive equality) and Minute in [startInclusive,
    /// endExclusive). Preserve input order and duplicate times.
    /// Return an empty list when none match.
    /// </returns>
    /// <remarks>
    /// Requires: all input conditions above must hold.
    /// Effects: neither the input nor its elements are modified.
    /// No outcome is specified for invalid calls.
    /// </remarks>
    public static IReadOnlyList<Sample> SelectWindow(
        IReadOnlyList<Sample> samples,
        string sensor,
        int startInclusive,
        int endExclusive)
    {
        List<Sample> result = new List<Sample>();

foreach (Sample s in samples)
{
    if (s.Sensor == sensor &&
        s.Minute >= startInclusive &&
        s.Minute < endExclusive)
    {
        result.Add(s);
    }
}

return result;
    }
}
