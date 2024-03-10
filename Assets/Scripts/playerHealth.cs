using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerHealth : MonoBehaviour
{

    public float value = 100;
    public RectTransform valueRectTransform;
    public GameObject gamePlayUI;
    public GameObject gameOverScreen;
    public ParticleSystem HealEff;


    private float _maxValue;
    void Start()
    {
        _maxValue = value;
        DrawHealthBar();
    }

    void Update()
    {
        isAlive();
        DrawHealthBar();
    }
    public void giveDmg(float dmg)
    {
        if (value > 0)
        {
            value -= dmg;
            DrawHealthBar();
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
            PlayerIsDead();
        }
    }

    private void DrawHealthBar()
    {
        valueRectTransform.anchorMax = new Vector2(value / _maxValue, 1);
    }
    private void PlayerIsDead()
    {
        gamePlayUI.SetActive(false);
        gameOverScreen.SetActive(true);
        GetComponent<playerController>().enabled = false;
        GetComponent<bulletCaster>().enabled = false;
        GetComponent<CameraRotation>().enabled = false;
    }

    public void AddHealth(float amount)
    {
        //Прибавить к текущему здоровью значение amount
        if (amount + value > _maxValue)
        {
            value = _maxValue;
        }
        else
        {
            value = value + amount;
        }
        HealEff.Play();
        //Обновить полоску здоровья
    }
}
