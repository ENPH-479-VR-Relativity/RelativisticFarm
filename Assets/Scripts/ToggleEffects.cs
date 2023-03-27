using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleEffects : MonoBehaviour
{
    public GlobalProperties playerGlobalProperties;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ToggleSpaceDistortion()
    {
        playerGlobalProperties.ToggleSpaceDistortion();
    }

    public void ToggleSpotlight()
    {
        playerGlobalProperties.ToggleSpotlight();
    }

    public void ToggleDoppler()
    {
        playerGlobalProperties.ToggleDoppler();
    }
}
