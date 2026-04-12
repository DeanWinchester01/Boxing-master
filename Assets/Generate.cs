using System;
using System.Collections.Generic;
using UnityEngine;

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
            //data.Add(obstacleToAdd, i);
            obstacles.Add(data);
            blocksLoaded += 1;
            //obstacles.Add(obstacleToAdd, i);
            //print(obstacleToAdd);
            //print(i);
            //print("");
        }
        eyeLevel = 1.7f;
    }

    void SpawnObstabacle()
    {
        GameObject newObstacle = Instantiate(obstaclePrefab[0]);
        Obstacle ob = newObstacle.AddComponent<Obstacle>();
        ob.Setup(spawnPos.position, this);
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
            //print("spawn ");
            //print(val);
            //print("");
            SpawnObstabacle();
        }
    }
}
