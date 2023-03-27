using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuEnabler : MonoBehaviour
{
    public bool IsMenuOpen = false;
    public GameObject menu;

    private int count = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ToggleMenu()
    {
        menu.SetActive(!IsMenuOpen);
    }
}
