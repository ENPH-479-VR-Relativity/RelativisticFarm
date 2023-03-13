using System.Collections;
using System.Collections.Generic;
using static System.Math;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;



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
            if (Sqrt(velocity[0] * velocity[0] + velocity[1] * velocity[1] + velocity[2] * velocity[2]) > 0.5)
            {
                print(velocity);
            }
        }
    }
}
