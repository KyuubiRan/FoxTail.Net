using FoxTail.Extensions;

namespace FoxTail.UnitTests.Extensions;

public class BoolExtensionTest
{
    [Test]
    public void NotTest()
    {
        const bool a = true;
        const bool b = false;

        Assert.Multiple(() =>
        {
            Assert.That(a.Not(), Is.False);
            Assert.That(b.Not(), Is.True);
        });
    }
}