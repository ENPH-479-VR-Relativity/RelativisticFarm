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
            double velocity_mag = Sqrt(velocity[0] * velocity[0] + velocity[1] * velocity[1] + velocity[2] * velocity[2]);
            
            if (velocity_mag > 0.1)
            {
                ScaleObject(velocity_mag);
            }
        }
    }

    private void ScaleObject(double velocity)
    {
        double c = 100.0;
        double scaling_factor = 1 + (velocity / c);

        if (transform.localScale.x * scaling_factor > 3 || transform.localScale.y * scaling_factor > 3 || transform.localScale.z * scaling_factor > 3) {
            transform.localScale = new Vector3((float) 0.5, (float) 0.5, (float) 0.5);
        } else
        {
            transform.localScale = new Vector3((float)(transform.localScale.x * scaling_factor), (float)(transform.localScale.y * scaling_factor), (float)(transform.localScale.z * scaling_factor));
        }
    }
}
