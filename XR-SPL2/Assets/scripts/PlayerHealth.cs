using UnityEngine;
using UnityEngine.Events;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField]private int maxhealth = 100, starthealth = 50; 

    public UnityAction healthchanged; 
    private float currenthealth = 0;
    private float pasthealth = - 999; 
    public float Health { get => currenthealth; set => currenthealth = value; }
    public int MaxHealth { get => maxhealth; }
    public void ResetHealth()
    {
        currenthealth = starthealth;
        OnUpdateHealth();
    }

    public void UpdateHealth(int value)
    {
        pasthealth = currenthealth;
        float newhealth = currenthealth + value; 
        currenthealth = Mathf.Clamp(newhealth,0,maxhealth);
        OnUpdateHealth();
    }
    private void OnUpdateHealth()
    {
        if(pasthealth != currenthealth)
        {
            healthchanged?.Invoke(); 
        }
    }
    public bool IsDead()
    {
        return currenthealth <= 0; 
    }

}
