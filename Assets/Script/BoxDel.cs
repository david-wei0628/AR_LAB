using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxDel : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        switch (this.name)
        {
            case "Sphere":
                if (this.transform.position.y < -10 && this.name == "Sphere")
                {
                    Destroy(this.gameObject);
                }
                break;
            case "CB":
                this.transform.LookAt(Camera.main.transform.position);
                break;

        }
    }

}
