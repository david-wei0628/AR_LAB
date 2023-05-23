using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SC_Change_btn : MonoBehaviour
{
    public GameObject ScenceList;
    Vector3 UIV3 = new Vector3(600, 1510, 0);
    public void OpenListScence()
    {
        Instantiate(ScenceList, UIV3, Quaternion.identity, this.gameObject.transform);
    }

    public void BTN_event()
    {
        if (!GameObject.FindGameObjectWithTag("ScenceList"))
        {
            OpenListScence();
        }
    }

    public void APPEXIT()
    {
        Application.Quit();
    }

    public void UIEXIT()
    {
        Destroy(this.gameObject);
    }

    public void ARImg_Change(string Scence)
    {
        SceneManager.LoadScene(Scence);
    }

    public void ARPlane_Change(string Scence)
    {
        SceneManager.LoadScene(Scence);
    }
}
