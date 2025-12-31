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
}