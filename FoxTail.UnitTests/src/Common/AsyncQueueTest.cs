using FoxTail.Common.Threading;

namespace FoxTail.UnitTests.Common;

public class AsyncQueueTest
{
    [Test]
    public void Test1()
    {
        const int end = 5;
        var que = new AsyncQueue<int>();

        var t1 = Task.Run(async () =>
        {
            for (var i = 0; i < end; i++)
            {
                await Task.Delay(500); 
                que.Enqueue(i);
                Console.WriteLine($"-> Enqueue: {i}, Time: {DateTime.Now:HH:mm:ss.fff}");
            }
        });

        var t2 = Task.Run(async () =>
        {
            for (var i = 0; i < end; i++)
            {
                Console.WriteLine($"<- Dequeue: {await que.DequeueAsync()}, Time: {DateTime.Now:HH:mm:ss.fff}");
            }
        });

        Task.WaitAll(t1, t2);
    }
}