using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public GameObject UICanvas;
    public GameObject LaserPointer;

    bool uiactive = false;

    void Start()
    {
        UICanvas.SetActive(false);
        LaserPointer.SetActive(false);
    }


    void Update()
    {
        if (OVRInput.GetDown(OVRInput.RawButton.X))
        {
            uiactive = !uiactive;
            UICanvas.SetActive(uiactive);
            LaserPointer.SetActive(uiactive);
        }
    }

    public void ResetLevel()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("InsomniacTest");
    }
}
