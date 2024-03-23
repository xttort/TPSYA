using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeCaster : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject granade;
    public Transform start_pos_gr;
    public float force = 10;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            
            var granadeC = Instantiate(granade);
            granadeC.transform.position = start_pos_gr.position;
            granadeC.GetComponent<Rigidbody>().AddForce(start_pos_gr.forward * force);
        }
    }
}
