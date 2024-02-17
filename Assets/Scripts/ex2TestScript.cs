using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ex2TestScript : MonoBehaviour
{
    public Transform startPoint;
    public Transform endPoint;

    public Color startMaterial;
    public Color endMaterial;

    public Material selfMaterial;



    [Range(0f, 1f)]
    public float value;

    void Update()
    {
        transform.position = Vector3.Lerp(startPoint.position, endPoint.position, value);
        transform.localScale = Vector3.Lerp(startPoint.localScale, endPoint.localScale, value);
        selfMaterial.color = Color.Lerp(startMaterial, endMaterial, value);
    }
}
