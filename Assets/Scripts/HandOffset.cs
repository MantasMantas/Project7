using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandOffset : MonoBehaviour
{
    public Transform realTarget;
    Transform virtualTarget;
    public Transform realHand;
    public float warpBoundary;

    bool croosed;

    Vector3 H0;
    Vector3 T;
    

    // Start is called before the first frame update
    void Start()
    {
        croosed = false;
    }

    // Update is called once per frame
    void Update()
    {
     
        if(transform.position.z > warpBoundary && transform.position.z < realTarget.position.z)
        {
            if(!croosed)
            {
                // hand position at the start of the warp
                H0 = transform.position;
                croosed = true;

                // warping formula W = aT; T = virual point - physichal point
                T = virtualTarget.position - realTarget.position;
            }
            

            float Ds = Vector3.Distance(realHand.position, H0);
            float Dp = Vector3.Distance(realHand.position, realTarget.position);

            float a = Ds/(Ds+Dp);
            Vector3 W = a * T;
            transform.position = new Vector3(realHand.position.x + W.x, realHand.position.y + W.y, realHand.position.z + W.z);
            
        }
        else
        {
            croosed = false;
        }
    }

    public void switchTarget(Transform newTarget)
    {
        virtualTarget = newTarget;
    }

}
