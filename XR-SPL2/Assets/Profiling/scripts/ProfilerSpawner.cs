using UnityEngine;

public class ProfilerSpawner : MonoBehaviour
{
    public GameObject prefab; 

    public float delay = 0.5f;
    private float time = 0; 
    void Start()
    {
        delay += Random.Range(0.05f, 2); 
    }

    void Update()
    {
        time += Time.deltaTime; 
        if(time > delay)
        {
            Instantiate(prefab,transform.position,transform.rotation);
            time = 0; 
            delay = Random.Range(0.05f, 2);
            Debug.Log("Prefab is spawned");
        }
    }
}
