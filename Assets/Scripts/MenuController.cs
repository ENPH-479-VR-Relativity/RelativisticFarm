using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour 
{

    private void SwitchColor(bool IsEffectEnabled, Image ButtonImage)
    {
        if (IsEffectEnabled) {
            ButtonImage.color = onColor;
        }  else {
             ButtonImage.color = offColor;
        }
    }
    public GlobalProperties globalProperties;
    public Image TimeDilationButton, SpatialDistortionButton, DopplerButton, SpotlightButton;
    public Color onColor, offColor;

    void Start()
    {
        TimeDilationButton.color = onColor;
        SpatialDistortionButton.color = onColor;
        DopplerButton.color = onColor;
        SpotlightButton.color = onColor;
    }

    public void ToggleTimeDilation()
    {
        globalProperties.IsTimeDilationEnabled = !globalProperties.IsTimeDilationEnabled;
        SwitchColor(globalProperties.IsTimeDilationEnabled, TimeDilationButton);
    }   

    public void ToggleSpatialDistortion()
    {
        globalProperties.IsSpatialDistortionEnabled = !globalProperties.IsSpatialDistortionEnabled;
        SwitchColor(globalProperties.IsSpatialDistortionEnabled, SpatialDistortionButton);
    }

    public void ToggleDoppler()
    {
        globalProperties.IsDopplerEnabled = !globalProperties.IsDopplerEnabled;
        SwitchColor(globalProperties.IsDopplerEnabled, DopplerButton);
    }

    public void ToggleSpotlight()
    {
        globalProperties.IsSpotlightEnabled = !globalProperties.IsSpotlightEnabled;
        SwitchColor(globalProperties.IsSpotlightEnabled, SpotlightButton);
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
