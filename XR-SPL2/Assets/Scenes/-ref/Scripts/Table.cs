using Unity.Mathematics;
using UnityEngine;

public class Table : MonoBehaviour
{
     private Gyroscope gyro; 
     private bool gyroSupported = false; 
     private Quaternion calibrationOffset = Quaternion.identity;
     private bool isCalibrated = false; 

     private Vector3 rotation; 

     void Start()
     {
        if (Camera.main == null) return; 

        //gyroSupported = SystemInfo.supportsGyroscope; 

        Quaternion cameraRotation = Camera.main.transform.rotation;
        Quaternion adjustedRotation = isCalibrated ? calibrationOffset * cameraRotation : cameraRotation;
        transform.rotation = adjustedRotation;

        if(gyroSupported)
        {
            /*
            gyro = Input.gyro; 
            gyro.enabled = true;

            rotationFix = new Quaternion(0,0,1,0);

            rotation = Vector3.zero;
             Debug.Log("[AR-DEBUG] GyroSupported: " + gyroSupported);
             */ 
        }
     }   

     void Update()
     {

        if (Camera.main == null) return; 

        //gyroSupported = SystemInfo.supportsGyroscope; 

        Quaternion cameraRotation = Camera.main.transform.rotation;
        cameraRotation.y = 0;
        Quaternion adjustedRotation = isCalibrated ? calibrationOffset * cameraRotation : cameraRotation;
        transform.rotation = adjustedRotation;
         #region hide
        /*
        if(!gyroSupported) return; 

        Quaternion deviceRotation = gyro.attitude * rotationFix; 
        
        if(isCalibrated)
        {
            transform.localRotation = referenceRotation * deviceRotation; 
        }
        */
        
        //rotation.x = -Input.gyro.rotationRateUnbiased.x; 
        //transform.rotation = Camera.main.transform.rotation;
        //Debug.Log("[AR-DEBUG]Gyro attitude: " + Input.gyro.attitude);
        //Debug.Log("[AR-DEBUG]Camera rotation: " + Camera.main.transform.rotation);
       // transform.localRotation = Quaternion.Inverse(deviceRotation);
        //Debug.DrawRay(transform.position, Physics.gravity, Color.red);
        #endregion

     }

     public void Calibrate()
     {
        if(Camera.main == null) return; 

        calibrationOffset = Quaternion.Inverse(Camera.main.transform.rotation); 
        calibrationOffset.y = 0;
        //Debug.Log("[AR-DEBUG] Table Calibrated");

        //Quaternion currentDeviceRotation = Camera.main.transform.rotation * rotationFix; 
        //referenceRotation = Quaternion.Inverse(currentDeviceRotation);
        isCalibrated = true; 
     }
}
