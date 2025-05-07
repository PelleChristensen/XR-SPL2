using UnityEngine;

public class FallingObjectScript : MonoBehaviour
{
    public Material[] materials; 

    [SerializeField]private int value; 

    public int Value { get { return value;} }
    private MeshRenderer renderer; 

    void Start()
    {
        int mats = materials.Length;
        renderer = GetComponent<MeshRenderer>(); 

        renderer.material = materials[Random.Range(0, mats)]; 
    }

    void OnCollisionEnter(Collision collision)
    {
         int mats = materials.Length;
        if(collision.gameObject.tag == "Ball")
        {
            renderer.material = materials[Random.Range(0, mats)]; 
        }
    }

}
