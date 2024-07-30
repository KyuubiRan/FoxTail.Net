using FoxTail.Extensions;

namespace FoxTail.UnitTests.Extensions;

public class CollectionExtensionTest
{
    [Test]
    public void ForEachListTest()
    {
        List<int> l = [2, 3, 4, 5, 6];
        l.OnEach(Console.WriteLine)
            .ToList()
            .Also(_=> { Console.WriteLine("------------------------------------------"); })
            .Select(x => x * 2)
            .ForEach(Console.WriteLine);
    }

    [Test]
    public void ForEachSetTest()
    {
        var set = new HashSet<string>
        {
            "ccc", "bbb", "aaa"
        };

        set.ForEach((x, i) => { Console.WriteLine($"ForEach: [{i}]={x}"); });
    }

    [Test]
    public void ForEachDictTest()
    {
        var dict = new Dictionary<string, int>
        {
            { "aaa", 111 }, { "bbb", 222 }, { "ccc", 333 }
        };

        dict.ForEach((k, v) => { Console.WriteLine($"ForEach: {k}={v}"); });
    }

    [Test]
    public void EmptyTest()
    {
        var list = new List<int>();
        Assert.That(list.IsEmpty(), Is.True);
        
        list.Add(1);
        Assert.That(list.IsNotEmpty(), Is.True);
    }
}