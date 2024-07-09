using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;

namespace FoxTail.Common.Exceptions;

public static class ExceptionUtils
{
    /// <summary>
    /// For has return type action.
    /// </summary>
    /// <param name="action"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Result<T> RunCatching<T>(Func<T> action)
    {
        try
        {
            return Result<T>.TSuccess(action());
        }
        catch (Exception e)
        {
            var edi = ExceptionDispatchInfo.Capture(e);
            return Result<T>.TFail(edi);
        }
    }

    /// <summary>
    /// For void return type action.
    /// </summary>
    /// <param name="action"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Result<object> RunCatching(Action action)
    {
        try
        {
            action();
            return Result<object>.Success();
        }
        catch (Exception e)
        {
            var edi = ExceptionDispatchInfo.Capture(e);
            return Result<object>.Fail(edi);
        }
    }
}