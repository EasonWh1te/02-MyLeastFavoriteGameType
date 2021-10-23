using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class CS_GameManager1 : MonoBehaviour
{

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            CS_GameManager.count++;
            //restart
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
