using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Table<K, V> // Key, Value
{
    static Dictionary<K, V> mapTB = new Dictionary<K, V>();

    public static Dictionary<K, V> GetTable()
    {
        return mapTB;
    }

    public static void SetTB(K _key, V _value)
    {
        mapTB.Add(_key, _value);
    }

    public static V GetTB(K _key)
    {
        V returnVal;
        mapTB.TryGetValue(_key, out returnVal);
        return returnVal;
    }
}
