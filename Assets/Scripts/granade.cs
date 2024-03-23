using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class granade : MonoBehaviour
{
    public float delay = 3;
    public GameObject explode;
    private void OnCollisionEnter(Collision collision)
    {
        Invoke("Explosion", delay);

    }
    void Explosion()
    {
        var explodeC = Instantiate(explode);
        explodeC.transform.position = transform.position;
        Destroy(gameObject);
    }
}
