
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

    public GameObject leftHand, rightHand;

    public int blocksMissed = 0;
    public int consequtive = 0;
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
        source.pitch = MainMenu.profile.speed / 5;
        source.Play();
        laser.SetActive(false);
        countdown = song.length;
        while (countdown > 0)
        {
            yield return null;
        }
        //yield return new WaitForSeconds(song.length);
        string scene = SceneManager.GetActiveScene().name;
        int number = int.Parse(scene.Substring(scene.Length-1));
        MainMenu.profile.levelsComplete.Add(number);
        finished.SetActive(true);
        finished.GetComponent<Finish>().Display(this);
        laser.SetActive(true);
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
        ob.Setup(transform.position, punch[0]);
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



        if (playTime > timeStamps[0])
        {
            timeStamps.RemoveAt(0);
            SpawnPunch();  
        }
    }

    //Load punches in from system storage, only use during development
    void LoadPunches()
    {
        TimeStamp stamp = Database.Load(source.name);
        

        for (int i = 0; i < stamp.stamp.Count; i++)
        {
            timeStamps.Add(stamp.stamp[i]);
            int obstacleToAdd = UnityEngine.Random.Range(1, Enum.GetNames(typeof(Obstacle.Punch)).Length);
            if (obstacleToAdd == 1)
                punch.Add(Obstacle.Punch.Jabb);
            if (obstacleToAdd == 2)
                punch.Add(Obstacle.Punch.Cross);
            if (obstacleToAdd == 3)
                punch.Add(Obstacle.Punch.Lhook);
            if (obstacleToAdd == 4)
                punch.Add(Obstacle.Punch.Rhook);
            if (obstacleToAdd == 5)
                punch.Add(Obstacle.Punch.Luppercut);
            if (obstacleToAdd == 6)
                punch.Add(Obstacle.Punch.Ruppercut);
        }
    }
    private void OnEnable()
    {
        //LoadPunches();
    }
}
