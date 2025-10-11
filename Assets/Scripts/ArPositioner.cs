using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ArPositioner : MonoBehaviour
{
    public GameObject arscene;
    public XROrigin arorg;
    public ARPlaneManager planeManager;
    public bool hasplaced;

    void Start()
    {
        if (planeManager != null)
        {
            planeManager.enabled = false;
        }
    }

    void Update()
    {
        if (!hasplaced)
        {
            if (!planeManager.enabled)
            {
                planeManager.enabled = true;
            }

            foreach (ARPlane plane in planeManager.trackables)
            {
                if (plane.alignment == PlaneAlignment.HorizontalUp)
                {
                    arscene.transform.position = plane.center;
                    arscene.transform.rotation = Quaternion.identity;
                    hasplaced = true;

                    planeManager.enabled = false;

                    foreach (var p in planeManager.trackables)
                    {
                        p.gameObject.SetActive(false);
                    }
                    break; 
                }
            }
        }
    }
}

//using System.Collections;
 //using System.Collections.Generic;
 //using Unity.XR.CoreUtils;
 //using UnityEngine;
 //using UnityEngine.XR.ARFoundation;
 //using UnityEngine.XR.ARSubsystems;

//public class ArPositioner : MonoBehaviour
//{
//    public GameObject arscene;
//    public XROrigin arorg;
//    public ARPlaneManager planeManager;
//    public bool hasplaced;
//    void Start()
//    {

//        // Vector3 playerpos = arorg.camera.transform.position;
//       // Vector3 playerpos = arorg.GetComponent<Camera>().transform.position;
//      //  arscene.transform.position = playerpos;

//    }


//    void Update()
//    {
//        if (!hasplaced)
//        {
//            foreach (ARPlane plane in planeManager.trackables)
//            {
//                if (plane.alignment == PlaneAlignment.HorizontalUp)
//                {
//                    arscene.transform.position = plane.center;
//                    arscene.transform.rotation = Quaternion.identity;
//                    hasplaced = true;

//                    planeManager.enabled = false;
//                    foreach(var p in planeManager.trackables)
//                    {
//                        p.gameObject.SetActive(false);
//                    }
//                    break;
//                }
//            }
//        }
//    }
//}
