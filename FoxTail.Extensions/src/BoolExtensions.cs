#if !FTE_BOOL_DISABLED
// ReSharper disable ConvertToExtensionBlock

namespace FoxTail.Extensions;

public static class BoolExtensions
{
#if NET10_0_OR_GREATER && !FTE_DISABLE_PROPERTY_EXTENSIONS
    extension(bool b)
    {
// Net 10 property extensions support
        public bool Not => !b;
    }
#else
    public static bool Not(this bool b) => !b;
#endif
}

#endif