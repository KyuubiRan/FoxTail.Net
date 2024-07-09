using FoxTail.Common;
using FoxTail.Common.Exceptions;

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

    [Test]
    public void Test2()
    {
        ExceptionUtils.RunCatching(() => { ArgumentExceptionUtils.ThrowIfNot(false, "This case will throw an exception."); })
            .OnFailure(x => { Console.WriteLine("Exception raised 01"); });
        ExceptionUtils.RunCatching(() => { ArgumentExceptionUtils.ThrowIfNot(() => false, "This case will throw an exception."); })
            .OnFailure(x => { Console.WriteLine("Exception raised 02"); });   

        ExceptionUtils.RunCatching(() => { ArgumentExceptionUtils.ThrowIf(true, "This case will throw an exception."); })
            .OnFailure(x => { Console.WriteLine("Exception raised 03"); });
        ExceptionUtils.RunCatching(() => { ArgumentExceptionUtils.ThrowIf(() => true, "This case will throw an exception."); })
            .OnFailure(x => { Console.WriteLine("Exception raised 04"); });
                
        ExceptionUtils.RunCatching(() => { ArgumentExceptionUtils.ThrowIfNot(true, "This case will not throw."); })
            .OnFailure(x => { Console.WriteLine("Exception raised 05"); });
        ExceptionUtils.RunCatching(() => { ArgumentExceptionUtils.ThrowIfNot(() => true, "This case will not throw."); })
            .OnFailure(x => { Console.WriteLine("Exception raised 06"); });
        
        ExceptionUtils.RunCatching(() => { ArgumentExceptionUtils.ThrowIf(false, "This case will not throw."); })
            .OnFailure(x => { Console.WriteLine("Exception raised 07"); });
        ExceptionUtils.RunCatching(() => { ArgumentExceptionUtils.ThrowIf(() => false, "This case will not throw."); })
            .OnFailure(x => { Console.WriteLine("Exception raised 08"); });
    }
}