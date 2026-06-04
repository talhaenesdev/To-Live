using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SerializableDictionary<TKey, TValue>
    : ISerializationCallbackReceiver
{
    [SerializeField]
    private List<TKey> keys = new();

    [SerializeField]
    private List<TValue> values = new();

    private Dictionary<TKey, TValue> dictionary = new();

    public Dictionary<TKey, TValue> Dictionary => dictionary;

    public TValue this[TKey key]
    {
        get => dictionary[key];
        set => dictionary[key] = value;
    }

    public void OnBeforeSerialize()
    {
        keys.Clear();
        values.Clear();

        foreach (var pair in dictionary)
        {
            keys.Add(pair.Key);
            values.Add(pair.Value);
        }
    }

    public void OnAfterDeserialize()
    {
        dictionary.Clear();

        for (int i = 0; i < Mathf.Min(keys.Count, values.Count); i++)
        {
            dictionary[keys[i]] = values[i];
        }
    }

    public void Add(TKey key, TValue value)
    {
        dictionary[key] = value;
    }

    public int Count => keys.Count;

    public void Clear() => dictionary.Clear();
    public void Remove(TKey key) => dictionary.Remove(key); 
}