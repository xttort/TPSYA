using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPotion : MonoBehaviour
{
    public float value = 10;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<playerHealth>())
        {   
            other.GetComponent<playerHealth>().AddHealth(value);
            Destroy(gameObject);
        }
    }
}
