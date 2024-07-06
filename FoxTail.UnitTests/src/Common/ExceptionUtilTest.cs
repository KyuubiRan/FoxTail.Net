using FoxTail.Common;

namespace FoxTail.UnitTests.Common;

public class ExceptionUtilTest
{
    [Test]
    public void Test1()
    {
        ExceptionUtils.RunCatching(() => 123)
            .OnSuccess(x => { Console.WriteLine("Success: " + x); })
            .OnFailure(x => { Console.WriteLine("Failure: " + x.Message); });

        Console.WriteLine("--------------------------------------------------------");
        
        ExceptionUtils.RunCatching(() =>
            {
                Console.WriteLine("Hello, World!");
                var i = default(int);
                var dd = 1;
                Console.WriteLine(dd / i);
            })
            .OnFailure(x => { Console.WriteLine("Exception raised!"); })
            .OnFailure<DivideByZeroException>(x => { Console.WriteLine("Div by zero exception!"); })
            .OnFailure<IOException>(x => { Console.WriteLine("This case will not be executed."); })
            // .RethrowIfFailure()
            ;
    }
}