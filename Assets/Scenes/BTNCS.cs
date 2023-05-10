using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.UI;

public class BTNCS : MonoBehaviour
{
    public GameObject ControllerGameObject;
    public Text TypeText;
    public GameObject Model;
    public void Exit()
    {
        Application.Quit();
    }

    public void TypeChange()
    {
        //if (ControllerGameObject.GetComponent<ARPlaneManager>().enabled)
        //{
        //    ControllerGameObject.GetComponent<ARTrackedImageManager>().enabled = true;
        //    ControllerGameObject.GetComponent<ARPlaneManager>().enabled = false;
        //    TypeText.text = "Image";

        //}
        //else if (ControllerGameObject.GetComponent<ARTrackedImageManager>().enabled)
        //{
        //    ControllerGameObject.GetComponent<ARTrackedImageManager>().enabled = false;
        //    ControllerGameObject.GetComponent<ARPlaneManager>().enabled = true;
        //    TypeText.text = "Plane";
        //}
        ControllerGameObject.GetComponent<ARTrackedImageManager>().enabled = !ControllerGameObject.GetComponent<ARTrackedImageManager>().enabled;

    }
}
