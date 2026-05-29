using System;
using UnityEngine;


public class Database : MonoBehaviour
{
    public static void Save(string key, object value)
    {
        string converted = JsonUtility.ToJson(value);
        print(converted);
        PlayerPrefs.SetString(key, converted);
    }


    public static UserProfile LoadUser(string key)
    {
        string loaded = PlayerPrefs.GetString(key);
        return JsonUtility.FromJson<UserProfile>(loaded);
    }

    public static TimeStamp Load(string key)
    {
        string loadedData = PlayerPrefs.GetString(key);
        return JsonUtility.FromJson<TimeStamp>(loadedData);
    }
}
