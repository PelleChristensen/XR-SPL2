using UnityEngine;

public class BallDestroyer : MonoBehaviour
{

    void OnCollisionEnter(Collision other)
    {
        PooledObject item = other.gameObject.GetComponent<PooledObject>();
        if(item != null)
        {
            item.Release();
        }
    }

}
