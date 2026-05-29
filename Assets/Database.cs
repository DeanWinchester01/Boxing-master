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


    public static UserProfile LoadUser(string key)
    {
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
