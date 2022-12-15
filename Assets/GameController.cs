using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    AudioSource src;
    public bool playerTped;

    public AudioClip crashSound;

    void Start()
    {
        src = GetComponent<AudioSource>();
        playerTped = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void playCrash()
    {
        src.PlayOneShot(crashSound);
    }
}
