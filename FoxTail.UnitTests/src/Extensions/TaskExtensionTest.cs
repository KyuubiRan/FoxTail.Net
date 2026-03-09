using FoxTail.Extensions;

namespace FoxTail.UnitTests.Extensions;

public class TaskExtensionTest
{
    private static async Task Foo()
    {
        await Task.Delay(TimeSpan.FromMilliseconds(100));
    }

    [Test]
    public async Task TaskTest()
    {
        Assert.ThrowsAsync<TimeoutException>(async () => await Foo().WithTimeout(TimeSpan.FromMilliseconds(50)));
        Assert.DoesNotThrowAsync(async () => await Foo().WithTimeout(TimeSpan.FromSeconds(200)));
    }

    [Test]
    public async Task TaskTest2()
    {
        Task? nullableTask = null;

        Assert.ThrowsAsync<NullReferenceException>(async () => await nullableTask);
        Assert.DoesNotThrowAsync(async () => await nullableTask.OrCompletedTask());
        
        Task<int>? nullableTask2 = null;
        
        var fromResult =  nullableTask2.OrCompletedTask(42);
        Assert.DoesNotThrowAsync(async () => await fromResult);
        Assert.That(await fromResult, Is.EqualTo(42));
    }
}