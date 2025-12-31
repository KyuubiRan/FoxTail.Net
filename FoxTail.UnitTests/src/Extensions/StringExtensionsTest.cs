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
        Console.WriteLine("str1 IsEmptyOrNull: " + str1.IsEmptyOrNull);
        Console.WriteLine("str2 IsEmptyOrNull: " + str2.IsEmptyOrNull);
        Console.WriteLine("str1 IsWhiteSpaceOrNull: " + str1.IsWhiteSpaceOrNull);
        Console.WriteLine("str2 IsWhiteSpaceOrNull: " + str2.IsWhiteSpaceOrNull);

        Console.WriteLine("----------------------------------------------------------");

        Console.WriteLine("str1 IfNullOrEmpty: " + str1.IfEmptyOrNull("Replaced"));
        Console.WriteLine("str2 IfNullOrEmpty: " + str2.IfEmptyOrNull("Replaced"));
        Console.WriteLine("str1 IfNullOrEmpty: " + str1.IfEmptyOrNull(() => "Replaced"));
        Console.WriteLine("str2 IfNullOrEmpty: " + str2.IfEmptyOrNull(() => "Replaced"));

        Console.WriteLine("----------------------------------------------------------");

        Console.WriteLine("str1 IfNullOrWhiteSpace: " + str1.IfWhiteSpaceOrNull("Replaced"));
        Console.WriteLine("str2 IfNullOrWhiteSpace: " + str2.IfWhiteSpaceOrNull("Replaced"));
        Console.WriteLine("str1 IfNullOrWhiteSpace: " + str1.IfWhiteSpaceOrNull(() => "Replaced"));
        Console.WriteLine("str2 IfNullOrWhiteSpace: " + str2.IfWhiteSpaceOrNull(() => "Replaced"));

        Console.WriteLine("----------------------------------------------------------");

        Console.WriteLine("str1[0] IsDigit: " + str1[0].IsDigitChar);
        Console.WriteLine("str3[0] IsDigit: " + str3[0].IsDigitChar);

        Console.WriteLine("----------------------------------------------------------");

        Console.WriteLine("str4 Format: " + str4.Fmt("World"));

        Console.WriteLine("----------------------------------------------------------");

        var barr = str1.ToByteArray();
        Console.WriteLine("str1 ToByteArray: " + string.Join(", ", barr));
        var barrs = barr.ByteArrayToString();
        Console.WriteLine("str1 ByteArrayToString: " + barrs);

        Console.WriteLine("----------------------------------------------------------");
    }
}