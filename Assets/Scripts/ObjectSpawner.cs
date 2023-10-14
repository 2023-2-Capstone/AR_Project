using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ObjectSpawner : MonoBehaviour
{
    public ARRaycastManager arRaycaster;
    public GameObject placeObject;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateCenterObject();
    }

    private void UpdateCenterObject(){
        Vector3 ScreenCenter = Camera.current.ViewportToScreenPoint(new Vector3(0.5f, 0.5f));
        List<ARRaycastHit> Hits = new List<ARRaycastHit>();
        arRaycaster.Raycast(ScreenCenter, Hits, TrackableType.Planes);

        if(Hits.Count > 0){
            Pose PlacementPose = Hits[0].pose;
            placeObject.SetActive(true);
            placeObject.transform.SetPositionAndRotation(PlacementPose.position, PlacementPose.rotation);     
        }else{
            placeObject.SetActive(false);
        }
    }
}
