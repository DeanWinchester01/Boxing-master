using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
public class HandTracker : MonoBehaviour
{
    public PlayerInput input;
    public Vector3 lastPos;
    public Vector3 newPos;
    public float speed;
    public Vector3 direction;
    public float updateInterval;

    float interval;

    
    //menu selector
    void OnActivate(InputValue value)
    {
        if (value.isPressed)
        {
            RaycastHit buttonHit;
            if(Physics.Raycast(transform.position, transform.forward, out buttonHit, float.MaxValue))
            {
                if(buttonHit.transform.TryGetComponent<Button>(out Button b))
                {
                    b.onClick.Invoke();
                }
            }
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
