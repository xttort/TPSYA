using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public float speed;
    public float lifeTime;


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
        transform.position += Vector3.forward * speed * Time.fixedDeltaTime;

    }

    private void OnCollisionEnter(Collision collision)
    {
        DestroyBullet();
    }

    private void DestroyBullet()
    {
        Destroy(gameObject);
    }
}
