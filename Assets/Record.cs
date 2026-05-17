using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Record : MonoBehaviour
{
    public AudioSource source;
    public AudioClip clip;
    bool record = false;
    //public int timeStamp;
    //public Dictionary<int, float> stamps = new Dictionary<int, float>();
    //public List<float> timeStamps = new List<float>();
    float time;

    TimeStamp stamp;

    void Start()
    {
        stamp = new TimeStamp();
        StartCoroutine(Play());
    }

    private void OnEnable()
    {
        TimeStamp loaded = Database.Load("TimeStamps");
        stamp = loaded;

        print(loaded);
    }

    IEnumerator Play()
    {
        yield return new WaitForSeconds(3);
        source.clip = clip;
        source.Play();
        record = true;

        yield return new WaitForSeconds(clip.length);

        Database.Save("TimeStamps", stamp);
        /*
        string save = t.ToString();
        print(save);
        string json = JsonUtility.ToJson(t);
        PlayerPrefs.SetString("TimeStamps", json);
        //print(save);
        */
    }

    void OnRecordButton()
    {
        //timeStamps.Add(time);
        if (!record) return;
        print(stamp != null);
        print(time);
        stamp.stamp.Add(time);
        //string newData = stamps.ToString();
        //print(newData);
        //TimeStamp newStamp = new TimeStamp();
        //newStamp.stamp.Add(time);
        
        
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
    public List<float> stamp = new List<float>();
}