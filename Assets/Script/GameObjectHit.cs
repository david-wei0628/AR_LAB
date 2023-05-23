using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectHit : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (this.transform.position.y < -20)
        {
            Destroy(this.gameObject.GetComponent<Rigidbody>());
            this.transform.position = Vector3.zero;
            this.transform.rotation = Quaternion.identity;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        Debug.Log("1");
        //this.gameObject.AddComponent<Rigidbody>();
    }
}
