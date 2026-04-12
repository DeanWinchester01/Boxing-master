using System.Collections.Generic;
using UnityEngine;

public class HandTracker : MonoBehaviour
{
    public Vector3 lastPos;
    public Vector3 newPos;
    public float speed;
    public Vector3 direction;
    public float updateInterval;

    float interval;
    
    public void TrackHand()
    {
        if(interval >= updateInterval)
        {
            interval = 0;
            lastPos = newPos;
            newPos = lastPos;
            Calculate();
        }
        interval += Time.fixedDeltaTime;
    }

    public void Calculate()
    {
        direction = newPos - lastPos;
        direction.Normalize();
        speed = (direction / interval).magnitude;
    }

    void FixedUpdate()
    {
        TrackHand();
    }
}
