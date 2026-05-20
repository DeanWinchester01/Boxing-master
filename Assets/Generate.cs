using System;
using System.Collections.Generic;
using UnityEngine;
using static Obstacle;

public class Generate : MonoBehaviour
{
    int blocksLoaded;
    List<Dictionary<string, float>> obstacles = new List<Dictionary<string, float>>();
    public List<GameObject> obstaclePrefab = new List<GameObject>();
    public Transform spawnPos;
    public Transform targetPos;

    public int blocksHitCorrect = 0;
    public int blocksHitWrong = 0;
    public int blocksMissed = 0;
    public int consequtive = 0;
    public float accuracy;
    public float eyeLevel;

    private void Start()
    {
        int minutesInSeconds = 60 * 3;
        for(float i = 0; i < minutesInSeconds; i+= UnityEngine.Random.Range(1,5))
        {
            int obstacleToAdd = UnityEngine.Random.Range(0, Enum.GetNames(typeof(Obstacle.Punch)).Length);
            Dictionary<string, float> data = new Dictionary<string, float>();
            data.Add("Obstacle", obstacleToAdd);
            data.Add("Time", i);
            obstacles.Add(data);
            blocksLoaded += 1;
        }
        eyeLevel = 1.7f;
    }

    void SpawnObstabacle()
    {
        GameObject newObstacle = Instantiate(obstaclePrefab[0]);
        int punch = UnityEngine.Random.Range(0, Enum.GetNames(typeof(Punch)).Length);
        Punch playerPunch = Punch.Jabb;
        switch (punch)
        {
            case 0:
                playerPunch = Punch.Jabb;
                break;
            case 1:
                playerPunch = Punch.Cross;
                break;
            case 2:
                playerPunch = Punch.Lhook;
                break;
            case 3:
                playerPunch = Punch.Luppercut;
                break;
            case 4:
                playerPunch = Punch.Rhook;
                break;
            case 5:
                playerPunch = Punch.Ruppercut; 
                break;

        }
        Obstacle ob = newObstacle.GetComponent<Obstacle>();
        ob.SetParent(this);
        ob.Setup(spawnPos.position, playerPunch);
    }

    void SpawnBomb()
    {

    }

    // Update is called once per frame
    private void Update()
    {
        if(obstacles.Count == 0)
        {
            print("Correct: " + blocksHitCorrect.ToString());
            print("Wrong: " + blocksHitWrong.ToString());
            print("Consequtive: " + consequtive.ToString());
            print("General  Accuracy: " + ((accuracy / blocksLoaded) * 100).ToString() + "%");
            return;
        }
        Dictionary<string, float> currentObstacle = obstacles[0];
        float time;
        currentObstacle.TryGetValue("Time", out time);

        if(time < Time.timeSinceLevelLoad)
        {
            obstacles.Remove(currentObstacle);
            float val;
            currentObstacle.TryGetValue("Obstacle", out val);
            SpawnObstabacle();
        }
    }
}
