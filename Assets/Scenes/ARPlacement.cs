using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.Experimental.XR;
using UnityEngine.UI;

public class ARPlacement : MonoBehaviour
{
    public GameObject arObjectToSpawn;
    public GameObject placementIndicator;
    private GameObject spawnedObject;
    private Pose PlacementPose;
    private ARRaycastManager aRRaycastManger;

    private bool placementPoseIsValid = false;
    public  Text TExt;
    public GameObject DebugDaw;

    void Start()
    {
        QualitySettings.vSyncCount = 0;//垂直同步
        Application.targetFrameRate = 60;//FPS禎數


        aRRaycastManger = FindObjectOfType<ARRaycastManager>();
        TExt.text = "START";
    }


    void Update()
    {
        //if (spawnedObject == null && placementPoseIsValid && Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        //if (placementPoseIsValid && Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        //{
        //    TExt.text = TExt.text + " 3";
        //    ARPlaceObject();
        //}
       
        UpdatePlacementPose();
        UpdatePlacementIndicator();

    }

    void UpdatePlacementIndicator()
    {
        //if (spawnedObject == null && placementPoseIsValid)
        if (placementPoseIsValid)
        {
            placementIndicator.SetActive(true);
            placementIndicator.transform.SetPositionAndRotation(PlacementPose.position, PlacementPose.rotation);
        }
        else
        {
            placementIndicator.SetActive(false);
        }
    }

    void UpdatePlacementPose()
    {
        var screenCenter = Camera.current.ViewportToScreenPoint(new Vector3(0.5f, 0.5f));
        var hits = new List<ARRaycastHit>();
        aRRaycastManger.Raycast(screenCenter, hits, TrackableType.Planes);
        placementPoseIsValid = hits.Count > 0;
        if (placementPoseIsValid)
        {
            PlacementPose = hits[0].pose;
            TExt.text = hits[0].pose.position.ToString() + " " + placementIndicator.activeSelf;
            //DebugDaw.transform.SetPositionAndRotation(PlacementPose.position , PlacementPose.rotation);

            //var cameraForward = Camera.current.transform.forward;
            //var cameraBearing = new Vector3(cameraForward.x, 0, cameraForward.z).normalized;
            //PlacementPose.rotation = Quaternion.LookRotation(cameraBearing);
        }
    }

    void ARPlaceObject()
    {
        /*spawnedObject = */Instantiate(arObjectToSpawn, PlacementPose.position, PlacementPose.rotation);
    }
}
