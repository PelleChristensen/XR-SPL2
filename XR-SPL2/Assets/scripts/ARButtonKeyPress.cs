using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class ARButtonKeyPress : MonoBehaviour
{
    public Button targetButton; // Assign this in Inspector. It's made to use the regular button component
    public InputActionReference touchPressAction; // Assign the Input Action that defines the interaction for this button

    private void OnEnable()
    {
        touchPressAction.action.performed += OnPress;
        touchPressAction.action.Enable();
    }

    private void OnDisable()
    {
        touchPressAction.action.performed -= OnPress;
        touchPressAction.action.Disable();
    }

    private void OnPress(InputAction.CallbackContext context)
    {
        targetButton.onClick.Invoke(); 
    }
}
