using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CS_GameManager : MonoBehaviour
{
    private static CS_GameManager instance = null;
    public static CS_GameManager Instance { get { return instance; } }

    public static int count = 0;

    private bool isGameOver;

    [SerializeField] GameObject myUI_TextWin;
    //[SerializeField] GameObject myUI_TextLose;


    [SerializeField] GameObject Boss;

    public void Start()
    {
        // hide win lose ui
        myUI_TextWin.SetActive(false);

        isGameOver = false;
    }

    private void Awake()
    {
        // instance
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            count++;
            //restart
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    public void CheckGameOver () {
		if (isGameOver == true) {
			return;
		}

		bool t_bossDead = true;
        if (Boss.activeSelf == true)
            t_bossDead = false;

		if (t_bossDead == true) {
			//myUI_TextWin.GetComponent<Text>().
            myUI_TextWin.SetActive (true);
			isGameOver = true;
			return;
		}

	}
}
