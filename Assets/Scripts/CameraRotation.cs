using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    public Transform CameraAxisTransform;
    
    [Header("camera settings")]
    public float rotateSensitivity;
    public float minAngle;
    public float maxAngle;

    void Start()
    {
        
    }

    void Update()
    {

        var newAngleX = CameraAxisTransform.localEulerAngles.x - Time.deltaTime * rotateSensitivity * Input.GetAxis("Mouse Y");
        if (newAngleX > 180)
            newAngleX -= 360; 

        newAngleX = Mathf.Clamp(newAngleX, minAngle, maxAngle);


        CameraAxisTransform.localEulerAngles = new Vector3(newAngleX, 0, 0);
        transform.localEulerAngles = new Vector3(0, transform.localEulerAngles.y + Time.deltaTime * rotateSensitivity * Input.GetAxis("Mouse X"), 0);
    }
}
