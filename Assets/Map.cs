using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    public AudioClip song;
    public AudioSource source;
    public List<Obstacle.Punch> punch;
    public List<float> timeBetween;

    void Start()
    {
        source.clip = song;
        source.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
