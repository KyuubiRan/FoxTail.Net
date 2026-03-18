using FoxTail.Extensions;

namespace FoxTail.UnitTests.Extensions;

public class ArrayExtensionTest
{
    [Test]
    public void ArrayTest()
    {
        int[]? a = null;
        int[] b = [];
        int[] c = [1, 2, 3];

        Assert.Multiple(() =>
        {
            Assert.That(a.OrEmpty().IsEmpty, Is.True);
            Assert.That(b.IsEmpty, Is.True);
            Assert.That(c.IsNotEmpty, Is.True);
        });
    }

    [Test]
    public void ArrayTest1()
    {
        int[] a = [1, 2, 3, 4, 5, 6, 7, 8];

        Console.WriteLine(a.Random());
        Console.WriteLine(a.Random());
        Console.WriteLine(a.Random());

        Console.WriteLine("================");
        var rng = new Random(42);
        
        Console.WriteLine(a.Random(rng));
        Console.WriteLine(a.Random(rng));
        Console.WriteLine(a.Random(rng));
    }
}