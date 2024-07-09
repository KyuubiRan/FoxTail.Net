using FoxTail.Extensions;

namespace FoxTail.UnitTests.Extensions;

public class ObjectExtensionTest
{
    [Test]
    public void Test1()
    {
        bool obj = new bool();
        int letret = obj.Let(x =>
        {
            Console.WriteLine(x);
            return x ? 100 : -100;
        });
        bool alsoret = obj.Also(Console.WriteLine);

        alsoret.Let(x =>
        {
            Console.WriteLine(x);
        });
    }
}