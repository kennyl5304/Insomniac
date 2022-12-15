using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BedJumpscare : MonoBehaviour
{
    GameController gc;
    public GameObject player;
    Rigidbody rb;
    float timeDelay = 3;

    // Start is called before the first frame update
    void Start()
    {
        gc = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Debug.Log(this.transform.position.z);
        if (gc.playerTped)
        {
            if (timeDelay >= 0)
            {
                timeDelay -= Time.deltaTime;
            }
            else if (timeDelay <= 0)
            {
                timeDelay = 3;
                gc.playCrash();
                crash();
            }
        }
        if(this.transform.position.z > -78.3)
        {
            Destroy(this.gameObject, 3);
        }
    }

    void crash()
    {
        transform.rotation = Quaternion.Euler(0, 90, 90);//new Vector3(transform.rotation.x, transform.rotation.y, 90f);
        transform.position = new Vector3(transform.position.x, 4f, transform.position.x);
        rb.AddForce(transform.forward * -10, ForceMode.Impulse);
    }
}
