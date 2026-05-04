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
        print("pressed");
        if (value.isPressed)
        {
            print(value.isPressed);
            RaycastHit buttonHit;
            if(Physics.Raycast(transform.position, transform.forward, out buttonHit, float.MaxValue))
            {
                print("hit object");
                print(buttonHit.transform);
                if(buttonHit.transform.TryGetComponent<Button>(out Button b))
                {
                    print("hit button");
                    print(b.transform);
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
