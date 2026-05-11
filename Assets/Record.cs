using System.Collections.Generic;
using UnityEngine;

public class Record : MonoBehaviour
{
    public AudioSource source;
    public AudioClip clip;
    bool record = false;
    //List<float> timeStamps = new List<float>();
    float time;


    void Start()
    {
        source.clip = clip;
        record = true;
    }

    void OnRecordButton()
    {
        //timeStamps.Add(time);
        print(time);
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
