using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;

public class HealthView : MonoBehaviour
{
    public RectTransform indicator;  

    private float maxamount; 

    void Start()
    {
        indicator.localScale = new Vector3(0,1,1);
    }
    public void UpdateHealth(float value)
    {
        Debug.Log("Updatehealth: " + value);
        indicator.localScale = new Vector3(value,1,1);
    }
}
