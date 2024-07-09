using FoxTail.Extensions;

namespace FoxTail.UnitTests.Extensions;

public class RandomExtensionsTest
{
    [Test]
    public void NextTest()
    {
        var random = new Random();
        for (int i = 0; i < 10; i++)
        {
            var result = random.NextSingle(10);
            Console.WriteLine(result);
            Assert.IsTrue(result is >= 0 and < 10);
        }
        
        for (int i = 0; i < 10; i++)
        {
            var result = random.NextSingle(-10, 10);
            Console.WriteLine(result);
            Assert.IsTrue(result is >= -10 and < 10);
        }   
        
        for (int i = 0; i < 10; i++)
        {
            var result = random.NextDouble(1000);
            Console.WriteLine(result);
            Assert.IsTrue(result is >= 0 and < 1000);
        }
        
        for (int i = 0; i < 10; i++)
        {
            var result = random.NextDouble(-100, 100);
            Console.WriteLine(result);
            Assert.IsTrue(result is >= -100 and < 100);
        }
    }
}