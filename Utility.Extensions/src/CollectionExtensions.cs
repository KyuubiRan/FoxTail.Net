using System.Runtime.CompilerServices;

namespace Utility.Extensions;

public static class CollectionExtensions
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsEmpty<T>(this T[] array) => array.Length == 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsNotEmpty<T>(this T[] array) => array.Length != 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsEmpty<T>(this List<T> array) => array.Count == 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsNotEmpty<T>(this List<T> array) => array.Count != 0;

    public static IEnumerable<T> OnEach<T>(this IEnumerable<T> source, Action<T> action)
    {
        return source.Select(x =>
        {
            action(x);
            return x;
        });
    }

    public static IEnumerable<T> OnEachIndexed<T>(this IEnumerable<T> source, Action<T, int> action)
    {
        var index = 0;
        return source.Select(x =>
        {
            action(x, index++);
            return x;
        });
    }

    public static void ForEach<T>(this IEnumerable<T> source, Action<T> action)
    {
        foreach (var item in source)
        {
            action(item);
        }
    }

    public static void ForEachIndexed<T>(this IEnumerable<T> source, Action<T, int> action)
    {
        var index = 0;
        foreach (var item in source)
        {
            action(item, index++);
        }
    }
}