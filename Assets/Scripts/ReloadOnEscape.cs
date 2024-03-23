using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReloadOnEscape : MonoBehaviour
{
    playerHealth helth;
    void Start()
    {
        helth = GetComponent<playerHealth>();
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) & helth.value == 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
