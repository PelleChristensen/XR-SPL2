using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerLogic : MonoBehaviour
{
    [SerializeField]PlayerHealth health; 
    [SerializeField]Animator animator; 
    InputAction forward; 
    InputAction backward; 

    private bool ISDead = false; 
    public float movementmodifier = 0.5f; 

    void Start()
    {
        forward = InputSystem.actions.FindAction("Keyboard/forward");
        backward = InputSystem.actions.FindAction("Keyboard/Back"); 

        health.ResetHealth();
    }


    void Update()
    {
        if(ISDead) return; 

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

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            health.UpdateHealth(-10);
            animator.SetTrigger("Take Damage");
        }

        if(health.Health <= 0)
        {
            ISDead = true; 
            UpDatePlayerState();
        } 
    }

    void UpDatePlayerState()
    {
        if(ISDead)
        {
            animator.SetTrigger("Die");
        }
    }

}
