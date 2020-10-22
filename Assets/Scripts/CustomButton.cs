using UnityEngine;
using UnityEngine.Events;

public class CustomButton : MonoBehaviour
{
    [System.Serializable]
    public class ButtonEvent : UnityEvent { }

    public float pressLength;
    bool pressed;
    bool touched;
    public ButtonEvent downEvent;
    public float reboundSpeed = 0.2f;


    Vector3 startPos;
    Rigidbody rb;

    void Start()
    {
        startPos = transform.position;
        rb = GetComponent<Rigidbody>();
        touched = false;
    }

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.layer == 0)
        {
            touched = true;
        }
    }

    void OnCollisionExit(Collision other)
    {
         if(other.gameObject.layer == 0)
        {
            touched = false;
        }
    }

    void OnCollisionStay(Collision other)
    {
        if(other.gameObject.layer == 0)
        {
            touched = true;
        }
    }

    void Update()
    {
        // If our distance is greater than what we specified as a press
        // set it to our max distance and register a press if we haven't already
        if(touched)
        {
            float distance = Mathf.Abs(transform.position.y - startPos.y);
            if (distance >= pressLength)
            {
                // Prevent the button from going past the pressLength
                transform.position = new Vector3(transform.position.x, startPos.y - pressLength, transform.position.z);
                if (!pressed)
                {
                    pressed = true;
                    // If we have an event, invoke it
                    downEvent?.Invoke();
                }
            }
            else
            {
                // If we aren't all the way down, reset our press
                pressed = false;
            }
        }
        else
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + reboundSpeed, transform.position.z);
            // Prevent button from springing back up past its original position
            if (transform.position.y > startPos.y)
            {
                transform.position = new Vector3(transform.position.x, startPos.y, transform.position.z);
            }
        }

        
        
    }
}