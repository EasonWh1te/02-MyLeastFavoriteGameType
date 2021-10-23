using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CS_Camera : MonoBehaviour
{
    [SerializeField] GameObject myPlayer;
    [SerializeField] float myLerpSpeed = 10;

    private void Update()
    {
        Vector3 t_newPosition = myPlayer.transform.position;
        t_newPosition.z = -10;
        this.transform.position = Vector3.Lerp(this.transform.position, t_newPosition, Time.deltaTime * myLerpSpeed);
    }
}
