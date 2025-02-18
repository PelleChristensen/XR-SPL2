using UnityEngine;

public class Singleton : MonoBehaviour
{
    private static Singleton instance; 

    public static Singleton Instance
    {
        get 
        {
            if (instance == null)
            {
                //SetupInstance(); 
            }
            return instance; 
        }
    }

    private void Awake()
    {
        if(instance == null)
        {
            instance = this; 
            DontDestroyOnLoad(this.gameObject); 
        }
        else
        {
            Destroy(gameObject);
        }
    }

}
