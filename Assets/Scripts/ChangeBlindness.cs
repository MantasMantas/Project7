using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeBlindness : MonoBehaviour
{
    [SerializeField] private string selectableTag = "Selectable";

    private Transform _selection;
    public float timeThreshold;
    float timeLeft;
    bool applyManipulation = false;
    public Transform buttons;
    public Transform realButton;
    public Transform targetButton;

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
                        Debug.Log("You are pointing towards " + hit.collider.name +": "+timeLeft);
                        

                    } else
                    {
                        applyManipulation = true;
                        Debug.Log("Apply that fucking manipulation.");
                        Vector3 difference = realButton.position - targetButton.position;
                        buttons.position = new Vector3(buttons.position.x + difference.x, buttons.position.y, buttons.position.z);
                    }
                }
                _selection = selection;
            } else
            {
                timeLeft = timeThreshold;
                Debug.Log("You are not looking at anything.");
            }
        }
    }
}
