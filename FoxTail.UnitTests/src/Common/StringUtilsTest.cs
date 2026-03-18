using FoxTail.Common.Utils;

namespace FoxTail.UnitTests.Common;

public class StringUtilsTest
{
    [Test]
    public void BuildStringTest()
    {
        var result = StringUtils.BuildString(sb =>
        {
            sb.Append("Hello");
            sb.Append(", ");
            sb.Append("World!");
        });

        Assert.That(result, Is.EqualTo("Hello, World!"));
    }
}