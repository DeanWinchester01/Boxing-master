using System;
using UnityEngine;

[ExecuteAlways]
public class Database : MonoBehaviour
{
    public static void Save(string key, object value)
    {
        string converted = JsonUtility.ToJson(value);
        print(converted);
        PlayerPrefs.SetString(key, converted);
    }

    public static TimeStamp Load(string key)
    {
        print("loading with key " + key);
        string loadedData = PlayerPrefs.GetString(key);
        print("Loaded data:\n" + loadedData);
        return JsonUtility.FromJson<TimeStamp>(loadedData);
    }
}
