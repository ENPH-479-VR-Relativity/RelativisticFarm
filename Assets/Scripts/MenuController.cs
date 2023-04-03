using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public GlobalProperties globalProperties;

    public void ToggleTimeDilation()
    {
        globalProperties.IsTimeDilationEnabled = !globalProperties.IsTimeDilationEnabled;
    }   

    public void ToggleSpatialDistoriton()
    {
        globalProperties.IsSpatialDistortionEnabled = !globalProperties.IsSpatialDistortionEnabled;
    }

    public void ToggleDoppler()
    {
        globalProperties.IsDopplerEnabled = !globalProperties.IsDopplerEnabled;
    }

    public void ToggleSpotlight()
    {
        globalProperties.IsSpotlightEnabled = !globalProperties.IsSpotlightEnabled;
    }



    public void TutorialBtn()
    {
        SceneManager.LoadScene("JedScene");
    }

    public void SpaceshipBtn()
    {
        SceneManager.LoadScene("JedScene");
    }

    public void FarmBtn()
    {
        SceneManager.LoadScene("JedScene");
    }

}
