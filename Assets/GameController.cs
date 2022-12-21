using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameController : MonoBehaviour
{

    AudioSource src;
    PlayerController player;
    public TMP_Text objective;

    public string currStage;
    public bool playerTped;
    DollyInterface dolly;
    public int gearsFound;

    public AudioClip crashSound;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        currStage = "start";
        src = GetComponent<AudioSource>();
        playerTped = false;
        dolly = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<DollyInterface>();
        Debug.Log(dolly);
        gearsFound = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(currStage == "hallway")
        {
            dolly.restart();
            dolly.dzEnabled = true;
            objective.text = "Navigate through your hallucinations";
            Debug.Log(Camera.main.fieldOfView);
        }
        else
        {
            dolly.dzEnabled = false;
            if (currStage == "clockPuzzle")
            {
                objective.text = "Fix the clock by finding the gears (" + gearsFound + "/3)";
            }
            else
            {
                objective.text = "Go to sleep";
            }
        }
    }

    public void playCrash()
    {
        src.PlayOneShot(crashSound);
    }
}
