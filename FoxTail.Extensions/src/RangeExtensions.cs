namespace FoxTail.Extensions;

public static class RangeExtensions
{
    /// <param name="range">The range</param>
    extension(Range range)
    {
        /// <summary>
        /// Execute an action for each integer in the specified range.
        /// </summary>
        /// <param name="action"></param>
        public void ForEach(Action<int> action)
        {
            var (start, length) = range.GetOffsetAndLength(int.MaxValue);
            for (var i = start; i < start + length; i++)
            {
                action(i);
            }
        }
    }
}