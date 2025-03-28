using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerLogic : MonoBehaviour
{
    [SerializeField]PlayerHealth health; 
    [SerializeField]HealthView view; 
    [SerializeField]Animator animator; 
    [SerializeField]PlayerMovement movement; 

    void Start()
    {
        health.ResetHealth();
    }

    void OnEnable()
    {
        health.healthchanged += UpdateHealthViews;  
    }

    private void UpdateHealthViews()
    {
        if(!health.IsDead())
        {
            view.UpdateHealth(health.Health / health.MaxHealth);
            return; 
        }
        Die();
    }

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            health.UpdateHealth(-10);
            animator.SetTrigger("Take Damage");
        }
    }
    private void Die()
    {
        movement.enabled = false; 
        animator.SetTrigger("Die");
    }
}
