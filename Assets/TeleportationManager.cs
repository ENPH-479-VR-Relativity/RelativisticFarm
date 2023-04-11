using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class TeleportationManager : MonoBehaviour
{

    [SerializeField] private InputActionAsset actionAsset;
    [SerializeField] private XRRayInteractor rayInteractor;
    [SerializeField] private TeleportationProvider tpProvider;
    private InputAction _joystick;
    private bool _isActive;
    private InputAction activate;
    private InputAction cancel;

    // Start is called before the first frame update
    void Start()
    {
        rayInteractor.enabled = false;

        activate = actionAsset.FindActionMap("XRI RightHand").FindAction("Teleport Mode Activate");
        activate.Enable();
        activate.performed += OnTeleportActivate;

        cancel = actionAsset.FindActionMap("XRI RightHand").FindAction("Teleport Mode Cancel");
        cancel.Enable();
        cancel.performed += OnTeleportCancel;

        _joystick = actionAsset.FindActionMap("XRI RightHand").FindAction("Move");
        _joystick.Enable();
    }

    public void CleanupCallbacks()
    {
        activate.performed -= OnTeleportActivate;
        cancel.performed -= OnTeleportCancel;
        activate.Disable();
        cancel.Disable();
        _joystick.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        if (!_isActive)
        {
            return;
        }

        if (_joystick.triggered)
        {
            return;
        }

        if (!rayInteractor.TryGetCurrent3DRaycastHit(out RaycastHit hit))
        {
            rayInteractor.enabled = false;
            _isActive = false;
        }

        TeleportRequest req = new TeleportRequest()
        {
            destinationPosition = hit.point,
        };

        tpProvider.QueueTeleportRequest(req);
        rayInteractor.enabled = false;
        _isActive = false;
    }

    private void OnTeleportActivate(InputAction.CallbackContext context)
    {
        rayInteractor.enabled = true;
        _isActive = true;
    }

    private void OnTeleportCancel(InputAction.CallbackContext context)
    {
        rayInteractor.enabled = false;
        _isActive = false;
    }
}
