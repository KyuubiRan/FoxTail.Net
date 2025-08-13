using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;

// ReSharper disable ArrangeObjectCreationWhenTypeNotEvident

namespace FoxTail.Common.Collections;

public class BiDictionary<TKey, TValue> : Dictionary<TKey, TValue>
    where TKey : notnull
    where TValue : notnull
{
    private readonly Dictionary<TValue, TKey> _reverseDictionary;

    /// <summary>
    /// Access to the reverse dictionary, which maps values to keys.
    /// </summary>
    public ReadOnlyDictionary<TValue, TKey> Reversed => _reverseDictionary.AsReadOnly();

    public BiDictionary()
    {
        _reverseDictionary = new();
    }

    public BiDictionary(int capacity) : base(capacity)
    {
        _reverseDictionary = new(capacity);
    }

    public new TValue this[TKey key]
    {
        get => base[key];
        set
        {
            if (ContainsKey(key))
            {
                _reverseDictionary.Remove(base[key]);
            }

            base[key] = value;
            _reverseDictionary[value] = key;
        }
    }

    public TKey this[TValue val]
    {
        get => _reverseDictionary[val];
        set
        {
            if (_reverseDictionary.TryGetValue(val, out var key))
            {
                Remove(key);
            }

            _reverseDictionary[val] = value;
            base[value] = val;
        }
    }

    public new bool ContainsValue(TValue value) => _reverseDictionary.ContainsKey(value);

    public TKey GetKey(TValue value) => _reverseDictionary[value];

    public bool TryGetKey(TValue value, [MaybeNullWhen(false)] out TKey key) => _reverseDictionary.TryGetValue(value, out key);

    public TValue GetValue(TKey key) => this[key];

    public bool Remove(TValue value)
    {
        return _reverseDictionary.Remove(value, out var key) && base.Remove(key);
    }

    public new bool Remove(TKey key)
    {
        return Remove(key, out var value) && _reverseDictionary.Remove(value);
    }

    public new void Clear()
    {
        base.Clear();
        _reverseDictionary.Clear();
    }

    public new int EnsureCapacity(int capacity)
    {
        _reverseDictionary.EnsureCapacity(capacity);
        return base.EnsureCapacity(capacity);
    }

    public new void Add(TKey key, TValue value)
    {
        if (ContainsKey(key))
        {
            _reverseDictionary.Remove(base[key]);
        }

        base.Add(key, value);
        _reverseDictionary[value] = key;
    }

    public void Add(KeyValuePair<TKey, TValue> kvp)
    {
        Add(kvp.Key, kvp.Value);
    }

    public new bool TryAdd(TKey key, TValue value)
    {
        if (ContainsKey(key))
        {
            return false;
        }

        Add(key, value);
        return true;
    }

    public bool TryAdd(KeyValuePair<TKey, TValue> kvp)
    {
        return TryAdd(kvp.Key, kvp.Value);
    }

    public void Add(TValue value, TKey key)
    {
        if (_reverseDictionary.TryGetValue(value, out var key1))
        {
            Remove(key1);
        }

        _reverseDictionary.Add(value, key);
        base.Add(key, value);
    }

    public bool TryAdd(TValue value, TKey key)
    {
        if (_reverseDictionary.ContainsKey(value))
        {
            return false;
        }

        Add(value, key);
        return true;
    }

    public bool TryAdd(KeyValuePair<TValue, TKey> kvp)
    {
        return TryAdd(kvp.Key, kvp.Value);
    }

    public Dictionary<TValue, TKey>.Enumerator GetReverseEnumerator()
    {
        return _reverseDictionary.GetEnumerator();
    }

    public void AddRange(IEnumerable<KeyValuePair<TKey, TValue>> items)
    {
        foreach (var item in items)
        {
            Add(item);
        }
    }

    public void AddRange(IEnumerable<KeyValuePair<TValue, TKey>> items)
    {
        foreach (var item in items)
        {
            Add(item.Key, item.Value);
        }
    }
}