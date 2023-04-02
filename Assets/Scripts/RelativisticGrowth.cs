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
    public float widthFactor = 0.05f;

    private void Start()
    {
        timeDilation = GetComponent<TimeDilation>();
    }

    private void Update ()
    {
        float growthVariation = Random.Range(0.8f, 1.5f);

        float scaleFactor = (Time.deltaTime * timeDilation.gamma * 0.05f) * resetScale / resetTime;

        if (transform.localScale.y > resetScale)
        {
            transform.localScale = new Vector3(
                (float)(baseScale),
                (float)(baseScale * growthVariation),
                (float)(baseScale)
            );
        }
        else
        {
            transform.localScale = transform.localScale + new Vector3(
                (float)(transform.localScale.x * scaleFactor * widthFactor),
                (float)(transform.localScale.y * scaleFactor * growthVariation),
                (float)(transform.localScale.z * scaleFactor * widthFactor)
            );
        }
    }
}
