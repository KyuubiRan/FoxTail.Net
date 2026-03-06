using System.Collections;
using System.Runtime.CompilerServices;

namespace FoxTail.Extensions;

#if !FTE_COLLECTION_DISABLED

public static class CollectionExtensions
{
    extension(ICollection collection)
    {
// Net 10 property extensions support
#if NET10_0_OR_GREATER && !FTE_DISABLE_PROPERTY_EXTENSIONS
        public bool IsEmpty => collection.Count == 0;

        public bool IsNotEmpty => collection.Count != 0;

#else
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool IsEmpty() => collection.Count == 0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool IsNotEmpty() => collection.Count != 0;
#endif
    }

    extension<TElement>(IEnumerable<TElement> source)
    {
        public void Collect()
        {
            using var enumerator = source.GetEnumerator();
            while (enumerator.MoveNext())
            {
                _ = enumerator.Current;
            }
        }

        public void ForEach(Action<TElement> action)
        {
            foreach (var item in source)
            {
                action(item);
            }
        }

        public IEnumerable<TElement> OnEach(Action<TElement> action)
        {
            return source.Select((x, i) =>
            {
                action(x);
                return x;
            });
        }

        public void ForEach(Action<TElement, int> action)
        {
            var i = -1;
            foreach (var item in source)
            {
                checked
                {
                    ++i;
                }

                action(item, i);
            }
        }

        public IEnumerable<TElement> OnEach(Action<TElement, int> action)
        {
            return source.Select((x, i) =>
            {
                action(x, i);
                return x;
            });
        }

        public IEnumerable<(TElement, int)> Indexed() => source.Select((x, i) => (x, i));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public string JoinToString(string separator) =>
            string.Join(separator, source);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public string JoinToString(char separator) => string.Join(separator, source);
    }

    extension<TKey, TValue>(IDictionary<TKey, TValue> source)
    {
        public void ForEach(Action<TKey, TValue> action)
        {
            foreach (var item in source)
            {
                action(item.Key, item.Value);
            }
        }

        public IEnumerable<KeyValuePair<TKey, TValue>> OnEach(Action<TKey, TValue> action)
        {
            return source.Select(x =>
            {
                action(x.Key, x.Value);
                return x;
            });
        }
    }
}

#endif