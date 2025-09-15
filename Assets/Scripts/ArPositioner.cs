using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class ArPositioner : MonoBehaviour
{
    public GameObject arscene;
    public XROrigin arorg;
    void Start()
    {

        // Vector3 playerpos = arorg.camera.transform.position;
        Vector3 playerpos = arorg.GetComponent<Camera>().transform.position;
        arscene.transform.position = playerpos;

    }

    
    void Update()
    {
        
    }
}
