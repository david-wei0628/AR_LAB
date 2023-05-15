using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using EnhancedTouch = UnityEngine.InputSystem.EnhancedTouch;

[RequireComponent(typeof(ARRaycastManager),typeof(ARPlaneManager))]
public class PlaneObject : MonoBehaviour
{
    [SerializeField]
    private GameObject prefab;

    private ARRaycastManager aRRaycastManager;
    private ARPlaneManager aRPlaneManager;
    private Transform aRTransform;

    List<ARRaycastHit> hits = new List<ARRaycastHit>(); 

    private void Awake()
    {
        aRRaycastManager = GetComponent<ARRaycastManager>();
        aRPlaneManager = GetComponent<ARPlaneManager>();        
    }

    private void OnEnable()
    {
        EnhancedTouch.TouchSimulation.Enable();
        EnhancedTouch.EnhancedTouchSupport.Enable();
        EnhancedTouch.Touch.onFingerDown += FingerDown;
    }

    private void OnDisable()
    {
        EnhancedTouch.TouchSimulation.Disable();
        EnhancedTouch.EnhancedTouchSupport.Disable();
        EnhancedTouch.Touch.onFingerDown -= FingerDown;
    }

    void FingerDown(EnhancedTouch.Finger finger)
    {
        if (finger.index != 0) return;

        if (aRRaycastManager.Raycast(finger.currentTouch.screenPosition, hits, TrackableType.PlaneWithinPolygon))
        {
            foreach (ARRaycastHit hit in hits)
            {
                Pose pose = hit.pose;
                pose.rotation.x = 90;
                var obj = Instantiate(prefab, pose.position + Vector3.up, pose.rotation);

                if (aRPlaneManager.GetPlane(hit.trackableId).alignment == PlaneAlignment.HorizontalUp)
                {
                    var position = obj.transform.position;
                    var cameraPosition = Camera.main.transform.position;
                    var direction = cameraPosition - position;
                    var targetRotationEuler = Quaternion.LookRotation(direction).eulerAngles;
                    var scaledEuler = Vector3.Scale(targetRotationEuler, obj.transform.up.normalized);
                    var targetRotation = Quaternion.LookRotation(scaledEuler);
                    obj.transform.rotation = obj.transform.rotation * targetRotation;
                }
            }
        }

    }
}
