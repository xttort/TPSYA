using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public float speed;
    public float lifeTime;
    public  Vector3 bulletForward = Vector3.forward;


    private void Start()
    {
        Invoke("DestroyBullet", lifeTime);
    }

    private void FixedUpdate()
    {
        MoveFixedUpdate();
    }
    private void MoveFixedUpdate()
    {
        transform.position += transform.forward * speed * Time.fixedDeltaTime;

    }

    private void OnCollisionEnter(Collision collision)
    {
        enemyDmg(collision);
        DestroyBullet();
    }

    private void DestroyBullet()
    {
        Destroy(gameObject);
    }
    
    private void enemyDmg(Collision collision)
    {
        if (collision.gameObject.GetComponent<enemyHealth>())
        {
            collision.gameObject.GetComponent<enemyHealth>().giveDmg(collision.gameObject.GetComponent<enemyHealth>().damage);
        }
    }
}
