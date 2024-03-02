using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletCaster : MonoBehaviour
{
    public bullet bulletPrefab;
    public Transform bullet_start_pos;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        fire();
        //Debug.Log(transform.position);
    }

   private void fire()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(bulletPrefab, bullet_start_pos.position, bullet_start_pos.rotation);
            //bul.GetComponent<bullet>().setForward(transform.forward); bullet bul = 
        }
    }
}
