using UnityEngine;
using UnityEngine.InputSystem;
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
        //Definér en Ray. Det er et objekt der består ag en position og en retning. 
        //Her skabes der en Ray ved at finde en position ud fra kameraet vha en position man trækker fra touchscreen.
          Ray ray = Camera.main.ScreenPointToRay(Touchscreen.current.primaryTouch.position.ReadValue());

        //EtRaucasthit objekt indeholder information om det objekt der bliver ramt + plus andet (læs dokumentation) 
        RaycastHit hit;
        
        //Der testes om noget rammes
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, interactableLayer))
        {
            //IPressable pressable = hit.collider.TryGetComponent<IPressable>(out IPressable pressable); 
            if (hit.collider.TryGetComponent<IPressable>(out IPressable pressable))
            {
                Debug.Log("[AR-DEBUG] A Pressable has been pressed");
                pressable.OnPressed();
            }
        }
    }
}



