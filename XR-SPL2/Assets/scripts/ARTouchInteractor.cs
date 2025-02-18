using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit.Interactors;
public class ARTouchInteractor : MonoBehaviour
{
    public XRRayInteractor rayInteractor; // Assign this in the inspector
    public LayerMask interactableLayer; // Set to detect interactable objects

    private void Update()
    {
        if (Touchscreen.current.primaryTouch.press.isPressed)
        {
            PerformRaycast();
        }
    }

    private void PerformRaycast()
    {
        Ray ray = Camera.main.ScreenPointToRay(Touchscreen.current.primaryTouch.position.ReadValue());
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, interactableLayer))
        {
            Casette interactable = hit.collider.GetComponent<Casette>();
            if (interactable)
            {
                interactable.OnPressed();
                //OnSelectEntered(null);
                Debug.Log($"Interacted with {hit.collider.name}");
            }
        }
    }
}



