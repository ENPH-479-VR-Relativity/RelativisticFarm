using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WelcomeManager : MonoBehaviour 
{

    public TeleportationManager tm;

    void Start()
    {
    }

    public void FarmBtn()
    {
        tm.CleanupCallbacks();
        SceneManager.LoadScene("JedScene");
    }
}
