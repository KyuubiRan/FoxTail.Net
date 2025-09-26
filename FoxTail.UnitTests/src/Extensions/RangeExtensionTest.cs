using FoxTail.Extensions;

namespace FoxTail.UnitTests.Extensions;

public class RangeExtensionTest
{
    [Test]
    public void ForEachTest()
    {
        (..100).ForEach(Console.WriteLine);
    }
}