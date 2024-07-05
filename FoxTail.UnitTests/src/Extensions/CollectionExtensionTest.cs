using FoxTail.Extensions;

namespace FoxTail.UnitTests.Extensions;

public class CollectionExtensionTest
{
    [Test]
    public void ForEachListTest()
    {
        int[] list = [1, 2, 3];

        list.OnEach(x => { Console.WriteLine($"OnEach: {x}"); })
            .ForEachIndexed((i, x) => { Console.WriteLine($"ForEachIndexed: idx = {i} value = {x}"); });

        list.OnEachIndexed((i, x) => { Console.WriteLine($"OnEachIndexed: idx = {i} value = {x}"); })
            .ForEach(x => { Console.WriteLine($"ForEach: {x}"); });
    }

    [Test]
    public void ForEachSetTest()
    {
        var set = new HashSet<string>
        {
            "ccc", "bbb", "aaa"
        };

        var set2 = set.OnEach(x => { Console.WriteLine($"OnEach: {x}"); }).ToHashSet();
        set2.ForEach(x => { Console.WriteLine($"ForEach: {x}"); });
    }

    [Test]
    public void ForEachDictTest()
    {
        var dict = new Dictionary<string, int>
        {
            { "aa", 1 }, { "bb", 2 }, { "cc", 3 }
        };
        
        var dict2 = dict.OnEach((k, v) => { Console.WriteLine($"OnEach: {k}={v}"); }).ToDictionary();
        dict2.ForEach((k, v) => { Console.WriteLine($"ForEach: {k}={v}"); });
    }
}