using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandGrab : MonoBehaviour
{
    public GameObject RightControllerAnchor;
    // Start is called before the first frame update
    void Start()
    {
        RightControllerAnchor = GameObject.Find("RightControllerAnchor");
    }

    // Update is called once per frame
    void Update()
    {
        GameObject grabbed = null;
        if (OVRInput.Get(OVRInput.Axis1D.SecondaryHandTrigger) >= 0.1)
        {
            Collider[] colliders = Physics.OverlapSphere(RightControllerAnchor.transform.position, 5);
            foreach (var collider in colliders)
            {
                if (collider.tag == "gear")
                {
                    if (grabbed != null) grabbed.transform.parent = null;
                    grabbed = collider.gameObject;
                    grabbed.transform.parent = RightControllerAnchor.transform;
                }
                if(collider.tag == "player")
                {
                    return;
                }
            }
        }
        else
        {
            if(grabbed != null)
            {
                grabbed.transform.parent = null;
            }
        }
    }
}
