using UnityEngine;
using UnityEngine.Events;

public class HealthData : MonoBehaviour
{
        [SerializeField]private int maxhealth, starthealth = 20; 
        private float currenthealth;
        private float previoushealth = -999;  

        public UnityAction OnHealthChanged; 

        public float Health { get => currenthealth; }
        public int MaxHealth { get => maxhealth; } 
        public void ChangeHealth(int value)
        {
            previoushealth = currenthealth; 
            float newhealth = currenthealth + value; 
            currenthealth = Mathf.Clamp(newhealth, 0, maxhealth); 
            if(currenthealth != previoushealth)
            {
                OnHealthChanged?.Invoke();
            }
        }
}
