using UnityEngine;

public class CasetteAnimator : MonoBehaviour
{
    [SerializeField] Animator animator; 

    Vector3 defaultsize; 
    Vector3 selectedsize; 
    void Start()
    {
        defaultsize = new Vector3(transform.localScale.x ,transform.localScale.y, transform.localScale.z);
        selectedsize = new Vector3(defaultsize.x *= 1.02f, defaultsize.y *= 1.02f, defaultsize.z *= 1.02f);
    }


    public void PopUp()
    {
        transform.localScale = selectedsize; 
    }

    public void PopDown()
    {
        transform.localScale = defaultsize;
    }
}
