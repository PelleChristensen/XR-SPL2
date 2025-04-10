using UnityEngine;
using Unity.Mathematics;

public class GyroTable : MonoBehaviour
{
     private Quaternion calibrationOffset = Quaternion.identity; 
     private bool isCalibrated = false; 
    void Start()
    {
        
    }


    void Update()
    {
        Quaternion cameraRotation = Camera.main.transform.rotation;
        Quaternion adjustedRotation = isCalibrated ? calibrationOffset * cameraRotation : cameraRotation;  
        transform.rotation = adjustedRotation; 
    }

    public void Calibrate()
    {
            if(Camera.main == null) return; 

            calibrationOffset = Quaternion.Inverse(Camera.main.transform.rotation);
            calibrationOffset.y = 0f; 
            isCalibrated = true; 
    }
}
