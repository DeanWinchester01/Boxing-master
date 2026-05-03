using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit.Inputs;
public class HandTracker : MonoBehaviour
{
    //public InputActionReference action;
    public PlayerInput input;
    public Vector3 lastPos;
    public Vector3 newPos;
    public float speed;
    public Vector3 direction;
    public float updateInterval;

    float interval;

    void OnActivate(InputValue value)
    {
        if (value.isPressed)
        {
            print("pressed activate button");
        }
    }
    
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

    void HandHit()
    {
        //device.SendHapticImpulse(0, 1, 0.1f);
    }

    
    

    void FixedUpdate()
    {
        TrackHand();
    }
}
