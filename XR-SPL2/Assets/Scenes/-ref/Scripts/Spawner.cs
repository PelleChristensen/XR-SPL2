using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]private GameObject prefab; 
   
    public int maxBalls = 3; 
    void Start()
    {
        Reset();
    }

    public void SpawnBall()
    {
        if(transform.childCount <= maxBalls)
        {
            GameObject ball = Instantiate(prefab,this.transform);
            Rigidbody rb = ball.GetComponent<Rigidbody>(); 
            rb.linearDamping = 2.3f; 
            rb.angularDamping = 1.3f; 
            rb.mass = 0.5f; 

        }
    }

    public void Reset()
    {
        while(transform.childCount > 0)
        {
            Destroy(transform.GetChild(0).gameObject);
        }
    }
}
