using System.Collections.Concurrent;

namespace FoxTail.Common.Threading;

public class AsyncQueue<T> : IDisposable
{
    private readonly SemaphoreSlim _sem = new(0);
    private readonly ConcurrentQueue<T> _que = new();

    public void Enqueue(T item)
    {
        _que.Enqueue(item);
        _sem.Release();
    }

    public async Task<T> DequeueAsync(CancellationToken token = default)
    {
        while (true)
        {
            await _sem.WaitAsync(token);
            if (_que.TryDequeue(out var item))
            {
                return item;
            }
        }
    }

    public int Count => _que.Count;
    public bool IsEmpty => _que.IsEmpty;
    public bool Contains(T item) => _que.Contains(item);

    public void Clear()
    {
        while (_que.TryDequeue(out _))
        {
        }

        _sem.Release(_sem.CurrentCount);
    }

    private void Dispose(bool disposing)
    {
        if (disposing)
        {
            _sem.Dispose();
        }
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}