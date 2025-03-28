using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

    InputAction forward; 
    InputAction backward; 
    public float movementmodifier = 1.5f; 

    void Start()
    {
        forward = InputSystem.actions.FindAction("Keyboard/forward");
        backward = InputSystem.actions.FindAction("Keyboard/Back"); 
    }

    

    // Update is called once per frame
    void Update()
    {
        float movement = 0; 
        if(forward.IsPressed())
        {
            movement += movementmodifier; 
        }
        if(backward.IsPressed())
        {
            movement -= movementmodifier; 
        }
        if(movement != 0)
        {
            this.gameObject.transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z + (movement * Time.deltaTime)); 
        }
    }
}
