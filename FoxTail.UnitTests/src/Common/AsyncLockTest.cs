using FoxTail.Common.Threading;

namespace FoxTail.UnitTests.Common;

public class AsyncLockTest
{
    [Test]
    public async Task Test()
    {
        var asyncLock = new AsyncLock();

        using (await asyncLock.LockAsync())
        {
            Console.WriteLine($"Locked at: {DateTime.Now}");
            await Task.Delay(1000);
        }

        Console.WriteLine($"Unlocked at: {DateTime.Now}");

        var t1 = Task.Run(async () =>
        {
            using (await asyncLock.LockAsync())
            {
                Console.WriteLine($"Locked at: {DateTime.Now}");
                await Task.Delay(1000);
            }

            Console.WriteLine($"Unlocked at: {DateTime.Now}");
        });

        var t2 = Task.Run(async () =>
        {
            using (await asyncLock.LockAsync())
            {
                Console.WriteLine($"Locked at: {DateTime.Now}");
                await Task.Delay(1000);
            }

            Console.WriteLine($"Unlocked at: {DateTime.Now}");
        });
        
        await Task.WhenAll(t1, t2);
    }
}