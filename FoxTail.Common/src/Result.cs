using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;

namespace FoxTail.Common;

public struct Result<T>
{
    internal struct Failure
    {
        public required ExceptionDispatchInfo ExceptionDispatchInfo;
        public Exception Exception => ExceptionDispatchInfo.SourceException;
    }

    internal object? Value { get; private set; }

    public bool IsSuccess => Value is not Failure;
    public bool IsFailure => Value is Failure;

    internal Result(object? value)
    {
        Value = value;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public T? GetOrDefault()
    {
        return Value is T t ? t : default;
    }

    public T? GetOrThrow()
    {
        if (Value is Failure f)
        {
            f.ExceptionDispatchInfo.Throw();
        }

        return (T?)Value;
    }

    public T? GetOrElse(T? other)
    {
        if (IsSuccess) return (T?)Value;
        return other;
    }

    public T? GetOrElse(Func<T?> action)
    {
        if (IsSuccess) return (T?)Value;
        return action();
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public Exception? ExceptionOrNull()
    {
        return Value is Failure f ? f.Exception : null;
    }

    public Result<T> OnSuccess(Action<T?> action)
    {
        if (IsFailure)
            return this;

        action((T?)Value);

        return this;
    }

    public Result<T> OnFailure(Action<Exception> action)
    {
        if (IsSuccess)
            return this;

        action(((Failure)Value!).Exception);

        return this;
    }

    /// <summary>
    /// Transform the result value to another value.
    /// </summary>
    /// <param name="selector">Transform function</param>
    /// <typeparam name="TR">Transformed type</typeparam>
    /// <returns>Transformed value</returns>
    /// <exception cref="InvalidOperationException">Thrown if the operation results in a failure.</exception>
    // ReSharper disable once InconsistentNaming
    public TR TSelect<TR>(Func<T?, TR> selector)
    {
        if (!IsSuccess)
            throw new InvalidOperationException("Cannot select from a failed result.");

        return selector((T?)Value);
    }

    /// <summary>
    /// Transform the result value to another value.(For void type result)
    /// </summary>
    /// <param name="selector">Transform function</param>
    /// <typeparam name="TR">Transformed type</typeparam>
    /// <returns>Transformed value</returns>
    /// <exception cref="InvalidOperationException">Thrown if the operation results in a failure.</exception>
    public TR Select<TR>(Func<TR> selector)
    {
        if (!IsSuccess)
            throw new InvalidOperationException("Cannot select from a failed result.");

        return selector();
    }

    public void RethrowIfFailure()
    {
        if (!IsFailure) return;

        var e = ((Failure)Value!).ExceptionDispatchInfo;
        e.Throw();
    }

    public Result<T> OnFailure<TException>(Action<TException> action) where TException : Exception
    {
        if (IsSuccess)
            return this;

        var exception = ((Failure)Value!).Exception;
        if (exception is TException te)
        {
            action(te);
        }

        return this;
    }

    // ReSharper disable once InconsistentNaming
    public static Result<T> TSuccess(T obj)
    {
        return new Result<T>(obj);
    }

    // ReSharper disable once InconsistentNaming
    public static Result<T> TFail(ExceptionDispatchInfo edi)
    {
        return new Result<T>(new Failure { ExceptionDispatchInfo = edi });
    }

    public static Result<object> Success()
    {
        return new Result<object>(null);
    }

    public static Result<object> Fail(ExceptionDispatchInfo edi)
    {
        return new Result<object>(new Failure { ExceptionDispatchInfo = edi });
    }
}