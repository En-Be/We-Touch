using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerGesture : MonoBehaviour
{
    private Controls _controls;
    private void Awake()
    {
        _controls = new Controls();
    }

    private void OnEnable()
    {
        _controls.Gesturing.Press.performed += HandlePress;
        _controls.Gesturing.Press.Enable();
    }

    private void OnDisable()
    {
        _controls.Gesturing.Press.performed -= HandlePress;
        _controls.Gesturing.Press.Disable();

    }

    private void HandlePress(InputAction.CallbackContext context)
    {
        Debug.Log("Pressed");
    }


}
