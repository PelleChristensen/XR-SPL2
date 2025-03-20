using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    [SerializeField] private ObjectPool pool;

    public float spawntime = 1.5f; 
    private float countdown = 0; 
    void Start()
    {
        countdown = 0.0f; 
        pool.Init();
    }

    void Update()
    {
        countdown += Time.deltaTime; 
        if(countdown >= spawntime)
        {
            //Debug.Log("Spawnball"); 
            countdown = 0; 

            PooledObject ball = pool.GetPooledObject(); 
            ball.gameObject.transform.position = this.gameObject.transform.position; 
        }
    }
}
