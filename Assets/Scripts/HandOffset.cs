using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandOffset : MonoBehaviour
{
    public Transform realTarget;
    public Transform virtualTarget;
    public Transform realHand;
    public float warpBoundary;
    bool croosed;

    Vector3 H0;
    

    // Start is called before the first frame update
    void Start()
    {
        //warpBoundary = 0;
        croosed = false;
    }

    // Update is called once per frame
    void Update()
    {
     
        if(transform.position.z > warpBoundary)
        {
            if(!croosed)
            {
                // hand position at the start of the warp
                H0 = transform.position;
                croosed = true;
            }

            
            // warping formula W = aT; T = virual point - physichal point
            Vector3 T = virtualTarget.position - realTarget.position;

            float Ds = Vector3.Distance(H0, realHand.position);
            float Dp = Vector3.Distance(realHand.position, realTarget.position);

            float a = Ds/(Ds+Dp);

            Vector3 W = a * T;

            if (realHand.position.z < realTarget.position.z)
            {
                transform.position = new Vector3(transform.position.x + W.x, transform.position.y + W.y, transform.position.z + W.z);
            }

        }
        else
        {
            croosed = false;
        }
    }
}
