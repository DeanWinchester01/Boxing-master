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

    public static string LoadUser(string key)
    {
        if (PlayerPrefs.HasKey(key))
        {
            return PlayerPrefs.GetString(key);
        }
        else
        {
            return null;
        }
    }


    public static TimeStamp Load(string key)
    {
        string loadedData = PlayerPrefs.GetString(key);
        return JsonUtility.FromJson<TimeStamp>(loadedData);
    }
}
