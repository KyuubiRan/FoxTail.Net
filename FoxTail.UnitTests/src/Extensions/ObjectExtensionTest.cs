using FoxTail.Extensions;

namespace FoxTail.UnitTests.Extensions;

public class ObjectExtensionTest
{
    [Test]
    public void Test1()
    {
        var bObj = false;
        var letRet = bObj.Let(x =>
        {
            Console.WriteLine(x);
            return x ? 100 : -100;
        });
        Console.WriteLine(letRet);
        var alsoRet = bObj.Also(Console.WriteLine);

        alsoRet.Let(Console.WriteLine);
    }
}