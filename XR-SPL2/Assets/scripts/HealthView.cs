using UnityEngine;
public class HealthView : MonoBehaviour
{
    public RectTransform indicator;  

    void Start()
    {
        indicator.localScale = new Vector3(0,1,1);
    }
    public void UpdateHealth(float value)
    {
        indicator.localScale = new Vector3(value,1,1);
    }
}
