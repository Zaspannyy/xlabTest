using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class DepthOfFieldController : MonoBehaviour
{
    Ray raycast;
    RaycastHit hit;
    bool isHit;
    float hitDistance;
   [SerializeField] Volume volume;
    DepthOfField depthOfField;

    void Start()
    {
        volume.profile.TryGet<DepthOfField>(out depthOfField);
    }

    // Update is called once per frame
    void Update()
    {
        raycast = new Ray(transform.position, transform.forward * 100);
        isHit = false;

        if(Physics.Raycast(raycast,out hit, 100f))
        {
            isHit = true;
            hitDistance = Vector3.Distance(transform.position, hit.point);
        }
        else
        {
            if (hitDistance < 100f)
            {
                hitDistance++;
            }
        }
        SetFocus();
    }
   void SetFocus()
    {
        depthOfField.focusDistance.value = hitDistance;
    }
}
