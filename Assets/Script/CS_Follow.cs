using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CS_Follow : MonoBehaviour
{
    [SerializeField] GameObject myPlayer;

    private void Update()
    {
        this.transform.position = myPlayer.transform.position;
    }
}
