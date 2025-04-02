using System.Runtime.CompilerServices;

namespace FoxTail.Extensions;

#if !FTE_BOOL_DISABLED

public static class BoolExtensions
{
    /// <summary>
    /// Reverse the boolean value.
    /// </summary>
    /// <param name="value">The bool value</param>
    /// <returns>Reversed bool value</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool Not(this bool value) => !value;
}

#endif
