using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CS_Portal : MonoBehaviour
{
    [SerializeField] string myTargetSceneName;

    private void OnTriggerEnter2D(Collider2D g_Collider2D)
    {
        if (g_Collider2D.GetComponent<CS_Player>() == true)
        {
            if (myTargetSceneName == "Level4")
                CS_Player.canShoot = true;
            SceneManager.LoadScene(myTargetSceneName);
        }
    }
}
