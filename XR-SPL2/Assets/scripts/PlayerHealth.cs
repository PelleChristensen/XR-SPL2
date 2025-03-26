using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField]private int maxhealth = 100, starthealth = 50; 
    [SerializeField]private HealthView view; 
    private float currenthealth = 0;  

    public float Health { get => currenthealth; set => currenthealth = value; }
    
    void Start()
    {
        
    }

    public void ResetHealth()
    {
        currenthealth = starthealth;
        UpdateView(); 
    }

    public void UpdateHealth(int value)
    {
        float oldhealth = currenthealth;
        float newhealth = currenthealth + value; 
        currenthealth = Mathf.Clamp(newhealth,0,maxhealth);

        Debug.Log("Updatehealth: old: " + oldhealth + " newhealth: " + newhealth + " currenthealth: " + currenthealth);
        if(currenthealth != oldhealth)
        {
            UpdateView();
        }
    }

    private void UpdateView()
    {
        float healthvalue = currenthealth / maxhealth; 
        view.UpdateHealth(healthvalue); 
    }

}
