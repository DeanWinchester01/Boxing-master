using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Record : MonoBehaviour
{
    public AudioSource source;
    public AudioClip clip;
    bool record = false;
    public int timeStamp;
    public Dictionary<int, float> stamps = new Dictionary<int, float>();
    public List<float> timeStamps = new List<float>();
    float time;

    List<TimeStamp> t = new List<TimeStamp>();

    void Start()
    {
        StartCoroutine(Play());
    }

    IEnumerator Play()
    {
        yield return new WaitForSeconds(3);
        source.clip = clip;
        source.Play();
        record = true;

        yield return new WaitForSeconds(10);
        string save = t.ToString();
        print(save);
        string json = JsonUtility.ToJson(t);
        PlayerPrefs.SetString("TimeStamps", json);
        //print(save);
    }

    void OnRecordButton()
    {
        //timeStamps.Add(time);
        if (!record) return;
        timeStamp++;
        stamps.Add(timeStamp, time);
        string newData = stamps.ToString();
        print(newData);
        TimeStamp newStamp = new TimeStamp();
        newStamp.stamp = timeStamp;
        newStamp.time = time;
        t.Add(newStamp);
        
        //timeStamps.Add(time);
        //print(time);
    }

    // Update is called once per frame
    void Update()
    {
        if (record)
        {
            time += Time.deltaTime;
        }
    }
}

[System.Serializable]
public class TimeStamp
{
    public int stamp;
    public float time;

    public static TimeStamp CreateFromJSON(string jsonString)
    {
        return JsonUtility.FromJson<TimeStamp>(jsonString);
    }
}