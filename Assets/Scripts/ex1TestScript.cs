using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ex1TestScript : MonoBehaviour
{
    public Transform Point1;
    public Transform Point2;

    private void Update()
    {
        transform.position = Vector3.Lerp(Point1.position, Point2.position, 0.5f);
    }
}
