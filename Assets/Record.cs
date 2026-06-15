using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Record : MonoBehaviour
{
    public AudioSource source;
    public AudioClip clip;
    public bool record = false;
    //public int timeStamp;
    //public Dictionary<int, float> stamps = new Dictionary<int, float>();
    //public List<float> timeStamps = new List<float>();
    float time;

    TimeStamp stamp;
    public Map map;
    public bool play;

    void Start()
    {
        stamp = new TimeStamp();
        map = GetComponent<Map>();
        if (!play) return;
        StartCoroutine(Play());
    }

    //Load punches in from system storage, only use during development
    void LoadPunches()
    {
        TimeStamp stamp = Database.Load(clip.name);

        if (map.timeStamps.Count != 0) return; 
        for (int i = 0; i < stamp.stamp.Count; i++)
        {
            map.timeStamps.Add(stamp.stamp[i]);
            int obstacleToAdd = UnityEngine.Random.Range(1, Enum.GetNames(typeof(Obstacle.Punch)).Length);
            if (obstacleToAdd == 1)
                map.punch.Add(Obstacle.Punch.Jabb);
            if (obstacleToAdd == 2)
                map.punch.Add(Obstacle.Punch.Cross);
            if (obstacleToAdd == 3)
                map.punch.Add(Obstacle.Punch.Lhook);
            if (obstacleToAdd == 4)
                map.punch.Add(Obstacle.Punch.Rhook);
            if (obstacleToAdd == 5)
                map.punch.Add(Obstacle.Punch.Luppercut);
            if (obstacleToAdd == 6)
                map.punch.Add(Obstacle.Punch.Ruppercut);
        }
    }

    private void OnEnable()
    {
        //TimeStamp loaded = Database.Load(clip.name);
        //stamp = loaded;
        LoadPunches();
        //print(loaded);
    }

    IEnumerator Play()
    {
        
        for (float i = 3; i > 0; i-= 0.1f)
        {

            yield return new WaitForSeconds(0.1f);
            print(i);
        }
        //yield return new WaitForSeconds(3);
        source.clip = clip;
        source.Play();
        record = true;

        yield return new WaitForSeconds(clip.length);

        Database.Save(clip.name, stamp);
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

    void OnRestart()
    {
        print("restarting");
        stamp.stamp = new List<float>();
        time = 0;
        record = false;
        StartCoroutine(Play());
    }

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