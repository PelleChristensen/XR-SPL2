using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class ARButtonKeyPress : MonoBehaviour
{
    public Button targetButton; // Assign this in Inspector. It's made t use the regular button component
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

    //the OnPress will be fired when the touchPressAction is active and will check if the ui element is clickable
    private void OnPress(InputAction.CallbackContext context)
    {
        if (IsTouchOverUI())
        {
            GameObject clickedObject = GetClickedUIElement();
            if (clickedObject != null)
            {
                Button button = clickedObject.GetComponent<Button>();
                if (button != null)
                {
                    button.onClick.Invoke(); // Simulate button press
                }
            }
        }
    }

    private bool IsTouchOverUI()
    {
        PointerEventData pointerData = new PointerEventData(EventSystem.current)
        {
            position = Touchscreen.current.primaryTouch.position.ReadValue()
        };

        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(pointerData, results);

        return results.Count > 0; // True if touching UI element
    }

    private GameObject GetClickedUIElement()
    {
        PointerEventData pointerData = new PointerEventData(EventSystem.current)
        {
            position = Touchscreen.current.primaryTouch.position.ReadValue()
        };

        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(pointerData, results);

        foreach (RaycastResult result in results)
        {
            if (result.gameObject.GetComponent<Button>() != null)
            {
                return result.gameObject; // Return the clicked UI button
            }
        }
        return null;
    }
}
