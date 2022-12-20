using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockPuzzle : MonoBehaviour
{
    GameController gc;
    public GameObject key;
    public GameObject smoke;
    // Start is called before the first frame update
    void Start()
    {
        gc = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        key.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(gc.gearsFound == 3)
        {
            key.SetActive(true);
            smoke.SetActive(false);
            gc.currStage = "ending";
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "gear")
        {
            if(this.gameObject.name == other.gameObject.name)
            {
                gc.gearsFound++;
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.tag == "gear")
        {
            if(this.gameObject.name == other.gameObject.name)
            {
                gc.gearsFound--;
            }
        }
    }
}
