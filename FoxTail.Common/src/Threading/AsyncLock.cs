namespace FoxTail.Common.Threading;

public sealed class AsyncLock : IDisposable
{
    private readonly SemaphoreSlim _sem = new(1, 1);

    public struct LockReleaser(SemaphoreSlim s) : IDisposable
    {
        public void Release() => Dispose();

        public void Dispose()
        {
            var sem = Interlocked.Exchange(ref s!, null);
            sem.Release();
        }
    }

    public async Task<LockReleaser> LockAsync(CancellationToken ct = default)
    {
        try
        {
            await _sem.WaitAsync(ct);
            return new LockReleaser(_sem);
        }
        catch
        {
            _sem.Release();
            throw;
        }
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
    }
}