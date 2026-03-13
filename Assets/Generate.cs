using System;
using System.Collections.Generic;
using UnityEngine;

public class Generate : MonoBehaviour
{
    List<Dictionary<string, float>> obstacles = new List<Dictionary<string, float>>();
    void Start()
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
            //obstacles.Add(obstacleToAdd, i);
            print(obstacleToAdd);
            print(i);
            print("");
        }
    }

    // Update is called once per frame
    void Update()
    {
        Dictionary<string, float> currentObstacle = obstacles[0];
        float time;
        currentObstacle.TryGetValue("Time", out time);

        if(time < Time.timeSinceLevelLoad)
        {
            obstacles.Remove(currentObstacle);
            float val;
            currentObstacle.TryGetValue("Obstacle", out val);
            print("spawn ");
            print(val);
            print("");
        }
    }
}
