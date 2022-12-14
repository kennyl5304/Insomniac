using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BedJumpscare : MonoBehaviour
{
    GameController gc;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        gc = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }

    void update()
    {
        if (gc.playerTped)
        {
            crash();
        }
        if(this.transform.position.z < 26)
        {
            Destroy(this.gameObject, 3);
        }
    }

    void crash()
    {
        transform.rotation = Quaternion.Euler(0, 90, 90);//new Vector3(transform.rotation.x, transform.rotation.y, 90f);
        transform.position = new Vector3(transform.position.x, 4f, transform.position.x);
        gc.playCrash();
    }
}
