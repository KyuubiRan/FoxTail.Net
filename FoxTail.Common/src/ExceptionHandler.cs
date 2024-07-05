namespace FoxTail.Common;

public struct ExceptionHandler(Exception? exception)
{
    public Exception? Exception { get; private set; } = exception;
    public bool ExceptionRaised => Exception is not null;

    public ExceptionHandler OnExcept(Action<Exception> act)
    {
        if (Exception is not null)
        {
            act(Exception);
        }
        return this;
    }

    public ExceptionHandler OnExcept<T>(Action<T> act) where T : Exception
    {
        if (Exception is T t)
        {
            act(t);
        }
        return this;
    }
}