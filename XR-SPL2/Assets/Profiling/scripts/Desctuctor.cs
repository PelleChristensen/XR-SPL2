using UnityEngine;

public class Desctuctor : MonoBehaviour
{
    void OnEnable()
    {

    }
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Ball")
        {
            FallingObjectScript fo = collision.gameObject.GetComponent<FallingObjectScript>(); 
            if(fo != null)
            {
                Messenger.DestroyAnObject(fo.Value);
            }
            
            Destroy(collision.gameObject);
            Debug.Log("Ball has been destroyed"); 
        }
    }
}
