using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boundaryScriopt : MonoBehaviour
{
    GameController gc;
    // Start is called before the first frame update
    void Start()
    {
        gc = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            gc.currStage = "clockPuzzle";
            this.gameObject.SetActive(false);
        }
    }
}
