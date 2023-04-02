using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Oculus.Interaction.Samples;

using static System.Math;

public class RelativisticGrowth : MonoBehaviour {

    private TimeDilation timeDilation;

    public float baseScale = 1f;
    public float resetScale = 3f;
    public float resetTime = 50f;

    private void Start()
    {
        timeDilation = GetComponent<TimeDilation>();
    }

    private void Update ()
    {
        float growthFactor = Random.Range(1f, 1.02f);

        float scaleFactor = (Time.deltaTime * timeDilation.gamma) * resetScale / resetTime;

        if (transform.localScale.y > resetScale)
        {
            transform.localScale = new Vector3(
                (float)(baseScale),
                (float)(baseScale * growthFactor),
                (float)(baseScale)
            );
        }
        else
        {
            transform.localScale = transform.localScale + new Vector3(
                (float)(transform.localScale.x * scaleFactor),
                (float)(transform.localScale.x * scaleFactor * growthFactor),
                (float)(transform.localScale.x * scaleFactor)
            );
        }
    }
}
