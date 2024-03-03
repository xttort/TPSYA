using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerHealth : MonoBehaviour
{

    public float value = 100;
    public RectTransform valueRectTransform;
    public GameObject gamePlayUI;
    public GameObject gameOverScreen;


    private float _maxValue;
    void Start()
    {
        _maxValue = value;
        DrawHealthBar();
    }

    void Update()
    {
        isAlive();
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
}
