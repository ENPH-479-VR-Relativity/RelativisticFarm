using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WelcomeManager : MonoBehaviour 
{


    void Start()
    {
    }

    public void FarmBtn()
    {
        SceneManager.LoadScene("JedScene");
    }
}
