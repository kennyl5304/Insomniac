using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    void OnEnable()
    {
        SceneManager.LoadScene("Menu");
    }
}
