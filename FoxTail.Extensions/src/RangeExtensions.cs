#if !FTE_RANGE_DISABLED
// ReSharper disable ConvertToExtensionBlock
using System;

namespace FoxTail.Extensions;

public static class RangeExtensions
{
    /// <param name="range">The range</param>
    /// <summary>
    /// Execute an action for each integer in the specified range.
    /// </summary>
    /// <param name="action"></param>
    public static void ForEach(this Range range, Action<int> action)
    {
        var (start, length) = range.GetOffsetAndLength(int.MaxValue);
        for (var i = start; i < start + length; i++)
        {
            action(i);
        }
    }
}

#endif