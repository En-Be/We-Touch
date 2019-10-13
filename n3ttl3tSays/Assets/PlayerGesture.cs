using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerGesture : MonoBehaviour
{
    private Controls _controls;

    public GameObject cube;
    private Vector2 pos;

    private void Awake()
    {
        _controls = new Controls();
    }

    private void OnEnable()
    {
        _controls.Gesturing.Press.performed += HandlePress;
        _controls.Gesturing.Drag.performed += HandleDrag;
        _controls.Gesturing.Press.Enable();
        _controls.Gesturing.Drag.Enable();

    }

    private void OnDisable()
    {
        _controls.Gesturing.Press.performed -= HandlePress;
        _controls.Gesturing.Drag.performed -= HandleDrag;
        _controls.Gesturing.Press.Disable();
        _controls.Gesturing.Drag.Disable();


    }

    private void HandlePress(InputAction.CallbackContext context)
    {
        Debug.Log("Pressed");
    }

    private void HandleDrag(InputAction.CallbackContext context)
    {
        pos = context.ReadValue<Vector2>();
        Vector3 worldPoint = Camera.main.ScreenToWorldPoint(pos);
        worldPoint.y = 0;
        cube.transform.position = worldPoint;
    }


}
