using FoxTail.Extensions;

namespace FoxTail.UnitTests.Extensions;

public class ListExtensionTest
{
    [Test]
    public void ListTest()
    {
        List<int> list = [1, 2, 3, 4, 5];
        var rng = new Random(123456);
        Console.WriteLine(string.Join(", ", list.Shuffle(rng)));
        
        var span = list.AsSpan();
        foreach (var t in span)
        {
            Console.WriteLine(t);
        }
    }
}