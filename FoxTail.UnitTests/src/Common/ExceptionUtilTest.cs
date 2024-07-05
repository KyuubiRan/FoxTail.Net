using FoxTail.Common;

namespace FoxTail.UnitTests.Common;

public class ExceptionUtilTest
{
    [Test]
    public void Test1()
    {
        ExceptionUtils.RunCatching(() =>
            {
                Console.WriteLine("Hello, World!");
                var i = default(int);
                var dd = 1;
                Console.WriteLine(dd / i);
            })
            .OnExcept(e => { Console.WriteLine("Exception raised!"); })
            .OnExcept<DivideByZeroException>(e => { Console.WriteLine("Divide by zero exception"); })
            .OnExcept<IOException>(e => { Console.WriteLine("IO exception"); })
            .OnExcept(e => { Console.WriteLine(e.StackTrace); });
    }
}