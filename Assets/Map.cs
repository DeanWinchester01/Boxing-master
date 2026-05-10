using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    public AudioClip song;
    public AudioSource source;
    public List<Obstacle.Punch> punch;
    public List<float> timeBetween;
    public GameObject punchCube;

    float playTime = 0;
    bool isPlaying = true;

    void Start()
    {
        StartCoroutine(Play());
    }

    IEnumerator Play()
    {
        yield return new WaitForSeconds(5);
        isPlaying = true;
        source.clip = song;
        source.pitch = MainMenu.profile.speed;
        source.Play();
    }

    void SpawnPunch()
    {
        
        GameObject newPunch = Instantiate(punchCube);
        Obstacle ob = newPunch.AddComponent<Obstacle>();
        ob.Setup(transform.position, punch[0]);
        punch.RemoveAt(0);
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlaying)
            playTime += Time.deltaTime;

        if (playTime > timeBetween[0])
        {
            timeBetween.RemoveAt(0);
            SpawnPunch();  
        }
    }
}
