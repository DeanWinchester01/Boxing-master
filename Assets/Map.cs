
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Map : MonoBehaviour
{
    public AudioClip song;
    public AudioSource source;
    public List<Obstacle.Punch> punch;
    public List<float> timeStamps;
    public GameObject punchCube;

    public GameObject finished;
    public GameObject laser;

    public Transform spawn;
    public Transform playerSpawn;
    public GameObject leftHand, rightHand;

    public int blocksMissed = 0;
    public int consequtive = 0;
    public int blocksHitWrong;
    public int blocksHitCorrect = 0;
    public float accuracy = 0;

    float playTime = 0;
    bool isPlaying = true;
    float countdown;

    void Start()
    {
        StartCoroutine(Play());
    }

    IEnumerator Play()
    {
        isPlaying = true;
        source.clip = song;
        source.pitch = MainMenu.profile.speed;
        source.Play();
        laser.GetComponent<MeshRenderer>().enabled = false;
        countdown = song.length;
        while (playTime < countdown)
        {
            print(((int)playTime).ToString()+"/"+((int)countdown).ToString());
            yield return null;
        }
        //yield return new WaitForSeconds(song.length);
        string scene = SceneManager.GetActiveScene().name;
        int number = int.Parse(scene.Substring(scene.Length-1));
        MainMenu.profile.levelsComplete.Add(number);
        finished.SetActive(true);
        finished.GetComponent<Finish>().Display(this);
        laser.GetComponent<MeshRenderer>().enabled = true;
        source.pitch = MainMenu.profile.speed;
        SetHands();
    }

    void SetHands()
    {
        //left blue
        //right green
        if (MainMenu.profile.hand)//right handed
        {
            leftHand.GetComponent<MeshRenderer>().material.color = Color.blue;
            rightHand.GetComponent<MeshRenderer>().material.color = Color.green;
        }
        else
        {
            leftHand.GetComponent<MeshRenderer>().material.color = Color.green;
            rightHand.GetComponent<MeshRenderer>().material.color = Color.blue;
        }
    }


    void SpawnPunch()
    {
        
        GameObject newPunch = Instantiate(punchCube);
        Obstacle ob = newPunch.GetComponent<Obstacle>();
        ob.SetParent(this);
        ob.Setup(spawn.position, punch[0]);
        punch.RemoveAt(0);
        print(ob.secondParentCode);
    }

    // Update is called once per frame
    void Update()
    {
        //print(Application.isEditor);
        //if (Application.isEditor) return;
        if (isPlaying)
            playTime += Time.deltaTime * MainMenu.profile.speed/5;


        if (timeStamps.Count == 0) return;
        //print(playTime.ToString() + "\t\t" + timeStamps[0]);
        //print(((int)playTime).ToString() + "\t\t" + (timeStamps[0] - (transform.position.z - 5) / MainMenu.profile.speed).ToString());
        print(timeStamps[0]);
        print((spawn.position.z - playerSpawn.position.z) / MainMenu.profile.speed);
        if (playTime > (timeStamps[0] - (spawn.position.z - playerSpawn.position.z)/MainMenu.profile.speed))
        {
            timeStamps.RemoveAt(0);
            SpawnPunch();  
        }
    }

    
}
