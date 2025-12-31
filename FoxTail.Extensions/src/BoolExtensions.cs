using System.Runtime.CompilerServices;

namespace FoxTail.Extensions;

#if !FTE_BOOL_DISABLED

public static class BoolExtensions
{
    extension(bool b)
    {
// Net 10 property extensions support
#if NET10_0_OR_GREATER && !FTE_DISABLE_PROPERTY_EXTENSIONS
        public bool Not => !b;

#else
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Not() => !b;
#endif
    }
}

#endif