using UnityEngine;

public class Gyrotest : MonoBehaviour
{
    private bool gyroSupported = false; 
    private Gyroscope gyro; 
    void Start()
    {
        gyroSupported = SystemInfo.supportsGyroscope; 

        if(gyroSupported)
        {
            Debug.Log("[AR-DEBUG] gyro is supported");
            gyro = Input.gyro; 
            gyro.enabled = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(gyroSupported)
        {
            transform.rotation = Camera.main.transform.rotation; 
            Debug.Log("[AR-DEBUG] rotation x: " + Camera.main.transform.rotation.x);
        }
        
    }
}
