using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    float startTime;
    public GameObject button;
    public GameObject text;

    void Start()
    {
        startTime = 3f;
        button.SetActive(false);
        text.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(startTime > 0)
        {
            startTime -= Time.deltaTime;
        }
        if(startTime <= 0)
        {
            button.SetActive(true);
            text.SetActive(true);
        }
    }

    public void restartGame()
    {
        SceneManager.LoadScene("InsomniacTest");
    }
}
