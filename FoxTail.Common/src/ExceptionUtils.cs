using System.Runtime.CompilerServices;

namespace FoxTail.Common;

public static class ExceptionUtils
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ExceptionHandler RunCatching(Action action)
    {
        try
        {
            action();
        }
        catch(Exception e)
        {
            return new ExceptionHandler(e);
        }

        return default;
    }
}