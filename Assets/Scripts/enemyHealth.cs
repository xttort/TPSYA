using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyHealth : MonoBehaviour
{
    public float value = 100;
    //public float lifetime = 100;
    public float damage = 10;
    public playerLvl plLvl;
    //getobjectoftype берет первый попавшийся обьект данного класса
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        isAlive();
    }
    public void giveDmg(float dmg)
    {
        plLvl.AddExp(10);
        if (value>0)
        {
            value -= dmg;
        }
        else
        {
            value = 0;
        }
    }

    private void isAlive()
    {
        if (value == 0)
        {
            Destroy(gameObject);
        }
    }
}
