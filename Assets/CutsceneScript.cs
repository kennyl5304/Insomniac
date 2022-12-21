using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using TMPro;

public class CutsceneScript : MonoBehaviour
{
    GameObject cutscene;
    bool playerInZone;
    public GameObject txtToDisplay;
    public GameObject player;
    GameController gc;
    public GameObject shadow;

    // Start is called before the first frame update
    void Start()
    {
        txtToDisplay.SetActive(false);
        gc = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        playerInZone = false;
        shadow.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            txtToDisplay.GetComponent<TMP_Text>().text = "Press A to go to sleep";
            txtToDisplay.SetActive(true);
            playerInZone = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            playerInZone = false;
            txtToDisplay.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (playerInZone)
        {
            this.gameObject.GetComponent<MeshRenderer>().enabled = true;
            if (OVRInput.Get(OVRInput.Button.One))
            {
                cutscene.GetComponent<PlayableDirector>().Play();
                shadow.SetActive(true);
            }
        }
        else
        {
            this.gameObject.GetComponent<MeshRenderer>().enabled = false;
        }
    }
}
