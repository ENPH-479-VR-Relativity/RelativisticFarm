using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class MenuController : MonoBehaviour 
{
    public GlobalProperties globalProperties;
    public Image TimeDilationButton, SpatialDistortionButton, DopplerButton, SpotlightButton, TutorialButton;
    public Color onColor, offColor;
    public Slider TimeDilationSlider, SpatialDistortionSlider, CSlider, SpotlightSlider;
    public Text TimeDilationText, SpatialDistortionText, CText, SpotlightText;

    void Start()
    {
        TimeDilationButton.color = onColor;
        SpatialDistortionButton.color = onColor;
        DopplerButton.color = onColor;
        SpotlightButton.color = onColor;

        TimeDilationSlider.value = globalProperties.TimeScalar;
        SpatialDistortionSlider.value = globalProperties.SpaceScalar;
        CSlider.value = globalProperties.LightSpeed;
        SpotlightSlider.value = globalProperties.SpotlightScalar;

        TimeDilationText.text = Math.Round(TimeDilationSlider.value, 2).ToString();
        SpatialDistortionText.text = Math.Round(SpatialDistortionSlider.value, 2).ToString();
        CText.text = Math.Round(CSlider.value, 2).ToString();
        SpotlightText.text = Math.Round(SpotlightSlider.value, 2).ToString();
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

    //  Adjust Sliders

    public void AdjustTimeDilationSlider()
    {
        globalProperties.TimeScalar = TimeDilationSlider.value;
        TimeDilationText.text = Math.Round(TimeDilationSlider.value, 2).ToString();
    }

    public void AdjustSpatialDistortionSlider()
    {
        globalProperties.SpaceScalar = SpatialDistortionSlider.value;
        SpatialDistortionText.text = Math.Round(SpatialDistortionSlider.value, 2).ToString();
    }

    public void AdjustCSlider()
    {
        globalProperties.LightSpeed = CSlider.value;
        CText.text = Math.Round(CSlider.value, 2).ToString();
    }

    public void AdjustSpotlightSlider()
    {
        globalProperties.SpotlightScalar = SpotlightSlider.value;
        SpotlightText.text = Math.Round(SpotlightSlider.value, 2).ToString();
    }

    public void TutorialBtn()
    {
        SceneManager.LoadScene("TutorialScene");
    }

    public void FarmBtn()
    {
        SceneManager.LoadScene("JedScene");
    }

    private void SwitchColor(bool IsEffectEnabled, Image ButtonImage)
    {
        if (IsEffectEnabled)
        {
            ButtonImage.color = onColor;
        }
        else
        {
            ButtonImage.color = offColor;
        }
    }
}
