using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public void TutorialBtn()
    {
        SceneManager.LoadScene("JedScene");
    }

    public void FarmBtn()
    {
        print("abc123");
        SceneManager.LoadScene("JedScene");
    }

    public void SpaceshipBtn()
    {
        SceneManager.LoadScene("JedScene");
    }
    
}
