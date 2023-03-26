using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

using Oculus.Interaction.Samples;

using static System.Math;

/// <summary>
/// Class <c>PlayerVelocity</c> extends MonoBehaviour and records the velocity of the player. Useful resources include:
/// http://man.hubwiz.com/docset/Unity_3D.docset/Contents/Resources/Documents/docs.unity3d.com/Manual/xr_input.html
/// http://man.hubwiz.com/docset/Unity_3D.docset/Contents/Resources/Documents/docs.unity3d.com/ScriptReference/XR.XRNode.html
/// https://docs.unity3d.com/ScriptReference/XR.CommonUsages.html
/// </summary>
public class PlayerVelocity : MonoBehaviour {

    private UnityEngine.XR.InputDevice device;

    private void Start()
    {
        var devices_at_node = new List<UnityEngine.XR.InputDevice>();
        UnityEngine.XR.InputDevices.GetDevicesAtXRNode(UnityEngine.XR.XRNode.Head, devices_at_node);

        if (devices_at_node.Count > 1)
        {
            print("Multiple headsets detected.");
        }
        else if (devices_at_node.Count == 0)
        {
            print("No headset detected.");
        }
        else
        {
            device = devices_at_node[0];
        }
    }

    private void Update()
    {

        if (device == null)
        {
            return;
        }

        Vector3 velocity;
        if (device.TryGetFeatureValue(UnityEngine.XR.CommonUsages.deviceVelocity, out velocity))
        {
            double velocityMagnitude = Sqrt(velocity[0] * velocity[0] + velocity[1] * velocity[1] + velocity[2] * velocity[2]);
            
            if (velocityMagnitude > 0.1)
            {
                ScaleObject(velocityMagnitude);
            }
        }
    }

    private void ScaleObject(double velocityMagnitude)
    {
        double c = 100.0; // TODO: growth is really fast rn, we should slow it down
        double scalingFactor = 1 + (velocityMagnitude / c);

        // The asset "dies" when it reaches it's growth limit (arb. 3)
        if (transform.localScale.x * scalingFactor > 3 || transform.localScale.y * scalingFactor > 3 || transform.localScale.z * scalingFactor > 3)
        {
            transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        } else
        {   // TODO: The crops are currently being scaled with the same magnitude in all directions
            // We may need to arbitrarily reduce scaling in x and z so that they don't collide when growing.
            float growthFactor = Random.Range(1f, 1.02f);
            transform.localScale = new Vector3((float)(transform.localScale.x * scalingFactor), (float)(transform.localScale.y * scalingFactor * growthFactor), (float)(transform.localScale.z * scalingFactor));
        }
    }
}
