using UnityEngine;

public class HealthPresenter : MonoBehaviour
{

    [SerializeField]private HealthView view; 
    [SerializeField]private HealthData data; 

    void Start()
    {
        data.OnHealthChanged += HealthChanged; 
    }
    
    void HealthChanged()
    {
        view.UpdateHealth(data.Health / data.MaxHealth); 
    }

    public void UpdateHealth(int value)
    {
        data.ChangeHealth(value); 
    }

}
