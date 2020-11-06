using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandOffset : MonoBehaviour
{
    public Transform realHand;
    public Transform virtualHand;
    public Transform realTarget;
    public float warpBoundary;

    public bool croosed;

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
     
        if(realHand.position.z > warpBoundary)
        {
            if(!croosed)
            {
                // hand position at the start of the warp
                H0 = realHand.position;
                croosed = true;
            }
            

            float Ds = Vector3.Distance(realHand.position, H0);
            float Dp = Vector3.Distance(realHand.position, realTarget.position);

            float a = Ds/(Ds+Dp);
            Vector3 W = a * T;
            virtualHand.position = new Vector3(realHand.position.x + W.x, realHand.position.y + W.y, realHand.position.z + W.z);
            
        }
        else
        {
            croosed = false;
        }
    }

    public void setT(Vector3 newT)
    {
        T = newT;
    }

}
