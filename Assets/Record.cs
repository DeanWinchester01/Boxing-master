using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
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
        StartCoroutine(Play());
    }

    IEnumerator Play()
    {
        yield return new WaitForSeconds(3);
        source.clip = clip;
        source.Play();
        record = true;
    }

    void OnRecordButton()
    {
        //timeStamps.Add(time);
        if (!record) return;
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
