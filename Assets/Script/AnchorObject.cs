using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using EnhancedTouch = UnityEngine.InputSystem.EnhancedTouch;

[RequireComponent(typeof(ARRaycastManager), typeof(ARPlaneManager))]
public class AnchorObject : MonoBehaviour
{
    [SerializeField]
    private Text UIRayObject;
    [SerializeField]
    private Image UIRayImg;
    [SerializeField]
    private GameObject RayObject;
    public GameObject GameWall;

    private ARRaycastManager aRRaycastManager;
    private ARPlaneManager aRPlaneManager;
    private Transform aRTransform;
    Vector3 Wall;

    List<ARRaycastHit> hits = new List<ARRaycastHit>();

    private void Start()
    {
        aRRaycastManager = GetComponent<ARRaycastManager>();
        aRPlaneManager = GetComponent<ARPlaneManager>();
        Wall = GameWall.transform.position;
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
            UIRayObject.text = finger.currentTouch.screenPosition.ToString();
        }

    }

    private void Update()
    {
        var screenCenter = Camera.current.ViewportToScreenPoint(new Vector3(0.5f, 0.3f));
        if (aRRaycastManager.Raycast(screenCenter, hits, TrackableType.PlaneWithinBounds))
        {
            //Debug.DrawRay(Camera.main.transform.position,hits[0].pose.position,Color.green);
            //GameWall.transform.position.y = hits[0].pose.position.y;
            
            Wall.y = hits[0].pose.position.y;
            GameWall.transform.position = Wall;
            RayObject.transform.SetPositionAndRotation(hits[0].pose.position, hits[0].pose.rotation);
            //UIRayObject.text = hits[0].pose.position.ToString();
        }
        else
        {
            Wall.y = 0;
            GameWall.transform.position = Wall;
            UIRayObject.text = "0";
        }
        
    }
}
