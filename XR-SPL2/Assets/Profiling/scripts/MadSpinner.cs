using Unity.Mathematics;
using UnityEngine;

public class MadSpinner : MonoBehaviour
{
    public float force = 5.0f; 
    void Update()
    {
        transform.Rotate(0f, force * Time.deltaTime, 0f);
    }
}
