#if !FTE_TASK_DISABLED

using System;
using System.Threading;
using System.Threading.Tasks;

namespace FoxTail.Extensions;

public static class TaskExtensions
{
    public static async Task<T> WithTimeout<T>(
        this Task<T> task,
        TimeSpan timeout,
        CancellationToken cancellationToken = default)
    {
        using var timeoutCts = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);
        timeoutCts.CancelAfter(timeout);

        try
        {
            return await task.WaitAsync(timeoutCts.Token).ConfigureAwait(false);
        }
        catch (OperationCanceledException) when (!cancellationToken.IsCancellationRequested)
        {
            throw new TimeoutException($"The operation has timed out after {timeout.TotalSeconds} seconds.");
        }
    }

    public static async Task WithTimeout(
        this Task task,
        TimeSpan timeout,
        CancellationToken cancellationToken = default)
    {
        using var timeoutCts = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);
        timeoutCts.CancelAfter(timeout);

        try
        {
            await task.WaitAsync(timeoutCts.Token).ConfigureAwait(false);
        }
        catch (OperationCanceledException) when (!cancellationToken.IsCancellationRequested)
        {
            throw new TimeoutException($"The operation has timed out after {timeout.TotalSeconds} seconds.");
        }
    }

    public static Task<T> OrCompletedTask<T>(this Task<T>? task, T defaultValue) => task ?? Task.FromResult(defaultValue);

    public static Task OrCompletedTask(this Task? task) => task ?? Task.CompletedTask;

    public static ValueTask<T> OrCompletedValueTask<T>(this ValueTask<T>? task, T defaultValue) => task ?? ValueTask.FromResult(defaultValue);

    public static ValueTask OrCompletedValueTask(this ValueTask? task) => task ?? ValueTask.CompletedTask;
}

#endif