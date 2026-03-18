using System.Text;

namespace FoxTail.Common.Utils;

public static class StringUtils
{
    public static string BuildString(Action<StringBuilder> builder)
    {
        var sb = new StringBuilder();
        builder(sb);
        return sb.ToString();
    }
}