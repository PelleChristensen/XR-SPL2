using UnityEngine;

public class Ground : MonoBehaviour
{
    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Ball")
        {
            other.transform.parent = null;
            Destroy(other.gameObject);
        }
    }
}
