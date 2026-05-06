using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
public class HandTracker : MonoBehaviour
{
    public Vector3 lastPos;
    public Vector3 newPos;
    public float speed;
    public Vector3 direction;
    public float updateInterval;
    public Transform ray;

    float interval;

    public LayerMask raycastlayer;
    //menu selector
    void OnActivate(InputValue value)
    {
        print("pressed");
        if (value.isPressed)
        {
            print(value.isPressed);
            RaycastHit buttonHit;
            Debug.DrawRay(transform.position, transform.up);
            Vector3 direction = (transform.up + transform.forward).normalized;
            if(Physics.Raycast(transform.position, direction, out buttonHit, float.MaxValue, raycastlayer))
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

    void DrawRay()
    {
        RaycastHit buttonHit;
        //Debug.DrawRay(transform.position, transform.up);
        Vector3 direction = (transform.up + transform.forward).normalized;
        if (Physics.Raycast(transform.position, direction, out buttonHit, float.MaxValue, raycastlayer))
        {
            Vector3 endPoint = buttonHit.point;
            float endPointDistance = (endPoint - transform.position).magnitude;
            ray.position = transform.position + direction * (endPointDistance / 2);
            ray.localScale = new Vector3(.01f, endPointDistance, .01f);
            ray.LookAt(endPoint);
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
        DrawRay();
    }
}
