using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class PlayerController : MonoBehaviour
{
    Rigidbody rb;
    AudioSource src;
    Vector3 force = Vector3.zero;
    public Transform camera;
    private InputDevice target;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        src = GetComponent<AudioSource>();
        force.z = 1;

        List<InputDevice> devices = new List<InputDevice>();
        InputDevices.GetDevices(devices);
        if(devices.Count > 0)
        {
            target = devices[0];
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(OVRInput.Get(OVRInput.Axis1D.SecondaryIndexTrigger) > 0f)
        {
            this.transform.position += Camera.main.transform.rotation * Vector3.forward * 5 * Time.deltaTime;
            var m = rb.velocity.magnitude;
            if (m < 0.01f)
            {
                rb.velocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
            }
        }
    }
}
