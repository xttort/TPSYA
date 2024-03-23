using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosion : MonoBehaviour
{
    // Start is called before the first frame update
    public float maxSize = 5;
    public float speed = 1;
    public float dmg = 5;
    void Start()
    {
        transform.localScale = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale += Vector3.one * Time.deltaTime * speed;
        if (transform.localScale.x >= maxSize)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        var playerHealth = other.GetComponent<playerHealth>();
        if (playerHealth != null)
        {
            playerHealth.giveDmg(dmg);
        }

        var enemyHealth = other.GetComponent<enemyHealth>();
        if (enemyHealth != null)
        {
            Debug.Log("dmgEn");
            enemyHealth.giveDmg(dmg);
        }
    }
}
