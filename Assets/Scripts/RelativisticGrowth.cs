using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Oculus.Interaction.Samples;

using static System.Math;

public class RelativisticGrowth : MonoBehaviour {

    private TimeDilation timeDilation;

    public bool diagnostics = false;

    public float maxScale = 3f; // As big as the object will get in the y-axis. 
    public float resetScale = 5f; // Effectively the amount of time before reset, in units of scale. While resetScale > scale > maxScale, the object won't grow but won't reset. 
    public float growthRate = 0.0035f;
    public Vector3 baseScale = new Vector3(1.0f, 1.0f, 1.0f);
    public float widthFactor = 0.05f;

    private Vector3 scale { get; set; } = Vector3.zero;
    private float actualMax = 0f;

    private void Start()
    {
        float growthVariation = Random.Range(0.8f, 1.5f);

        timeDilation = GetComponent<TimeDilation>();

        actualMax = maxScale * Random.Range(0.9f, 1.1f);

        scale = new Vector3(
            (float)(baseScale.x),
            (float)(baseScale.y * growthVariation),
            (float)(baseScale.z)
        );

        transform.localScale = new Vector3(
            (float)(baseScale.x),
            (float)(baseScale.y * growthVariation),
            (float)(baseScale.z)
        );
    }

    private void Update ()
    {
        float growthVariation = Random.Range(0.8f, 1.5f);

        float scaleFactor = Time.deltaTime * timeDilation.gamma * growthRate;

        if (scale.y > resetScale)
        {
            scale = new Vector3(
                (float)(baseScale.x),
                (float)(baseScale.y * growthVariation),
                (float)(baseScale.z)
            );

            actualMax = maxScale * Random.Range(0.9f, 1.1f);
        }
        else
        {
            scale = new Vector3(
                (float)(scale.x * (1 + scaleFactor * widthFactor)),
                (float)(scale.y * (1 + scaleFactor * growthVariation)),
                (float)(scale.z * (1 + scaleFactor * widthFactor))
            );
        }

        if (scale.y < maxScale)
        {
            transform.localScale = scale;
        }

        if (diagnostics)
        {
            print(scale);
        }
    }
}
