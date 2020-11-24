﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckGaze : MonoBehaviour
{
    [SerializeField] private string selectableTag = "Selectable";

    private Transform _selection;
    public float timeThreshold;
    float timeLeft;
    public bool applyManipulation = false;

    private void Start()
    {
        timeLeft = timeThreshold;
    }
    void Update()
    {
        
        Vector3 forward = transform.TransformDirection(Vector3.forward) * 10;
        var cameraCenter = new Vector3(UnityEngine.XR.XRSettings.eyeTextureWidth / 2, UnityEngine.XR.XRSettings.eyeTextureWidth / 2);
        var ray = Camera.main.ScreenPointToRay(cameraCenter);
        RaycastHit hit;
        
        if(Physics.Raycast(ray, out hit))
        {
            var selection = hit.transform;
            if (selection.CompareTag(selectableTag))
            {
                var selectionRenderer = selection.GetComponent<Renderer>();
                if(selectionRenderer != null)
                {
                    if(timeLeft >= 1)
                    {
                        timeLeft -= Time.deltaTime;
                        //Debug.Log("You are pointing towards " + hit.collider.name +": "+timeLeft);
                        

                    } else
                    {
                        if(!applyManipulation)
                        {
                            applyManipulation = true;
                        }
                    }
                }
                _selection = selection;
            } else
            {
                timeLeft = timeThreshold;
                applyManipulation = false;
                //Debug.Log("You are not looking at anything.");
            }
        }
    }

}
