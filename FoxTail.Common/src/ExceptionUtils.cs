using System.Runtime.CompilerServices;

namespace FoxTail.Common;

public static class ExceptionUtils
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void RunCatching(Action action)
    {
        try
        {
            action();
        }
        catch
        {
            // ignored
        }
    }
}