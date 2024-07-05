namespace FoxTail.UnitTests.Extensions;

using FoxTail.Extensions;

public class StringExtensionsTest
{
    [Test]
    public void Test1()
    {
        const string str1 = "Hello World!";
        const string str2 = "    ";
        const string str3 = "123456789";
        const string str4 = "Hello {0}";

        Console.WriteLine("----------------------------------------------------------");
        
        Console.WriteLine("str1 IsNullOrEmpty: " + str1.IsNullOrEmpty());
        Console.WriteLine("str2 IsNullOrEmpty: " + str2.IsNullOrEmpty());
        Console.WriteLine("str1 IsNullOrWhiteSpace: " + str1.IsNullOrWhiteSpace());
        Console.WriteLine("str2 IsNullOrWhiteSpace: " + str2.IsNullOrWhiteSpace());
        
        Console.WriteLine("----------------------------------------------------------");

        Console.WriteLine("str1 IfNullOrEmpty: " + str1.IfNullOrEmpty("Replaced"));
        Console.WriteLine("str2 IfNullOrEmpty: " + str2.IfNullOrEmpty("Replaced"));
        Console.WriteLine("str1 IfNullOrEmpty: " + str1.IfNullOrEmpty(() => "Replaced"));
        Console.WriteLine("str2 IfNullOrEmpty: " + str2.IfNullOrEmpty(() => "Replaced"));
        
        Console.WriteLine("----------------------------------------------------------");
        
        Console.WriteLine("str1 IfNullOrWhiteSpace: " + str1.IfNullOrWhiteSpace("Replaced"));
        Console.WriteLine("str2 IfNullOrWhiteSpace: " + str2.IfNullOrWhiteSpace("Replaced"));
        Console.WriteLine("str1 IfNullOrWhiteSpace: " + str1.IfNullOrWhiteSpace(() => "Replaced"));
        Console.WriteLine("str2 IfNullOrWhiteSpace: " + str2.IfNullOrWhiteSpace(() => "Replaced"));
        
        Console.WriteLine("----------------------------------------------------------");

        Console.WriteLine("str1 IsDigit: " + str1[0].IsDigit());
        Console.WriteLine("str3 IsDigit: " + str3[0].IsDigit());
        
        Console.WriteLine("----------------------------------------------------------");

        Console.WriteLine("str4 Format: " + str4.Format("World"));
        
        Console.WriteLine("----------------------------------------------------------");
        
        var barr = str1.ToByteArray();
        Console.WriteLine("str1 ToByteArray: " + string.Join(", ", barr));
        var barrs = barr.ByteArrayToString();
        Console.WriteLine("str1 ByteArrayToString: " + barrs);
        
        Console.WriteLine("----------------------------------------------------------");
    }
}