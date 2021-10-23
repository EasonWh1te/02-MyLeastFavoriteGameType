using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CS_Bullet : MonoBehaviour
{
    [SerializeField] Rigidbody2D myRididbody2D;
    [SerializeField] float mySpeed;
    
    private Vector2 myDirection = Vector2.right;
    private GameObject myOrigin;

    [SerializeField] float myLiveTime;
    private float myKillTime;
    public void Init(Vector2 g_direction, GameObject g_origin)
    {
        myDirection = g_direction;
        myOrigin = g_origin;

        myKillTime = Time.time + myLiveTime;

        myRididbody2D.velocity = myDirection * mySpeed;
        this.transform.right = myDirection;
    }

    private void Update()
    {
        //Ϊ��Ҫʵʱ�����ٶȣ�
        //1.������Kinematic���ԣ������������ԸĻ�Dynamic 2.���Թر��ӵ�������ֻ��ʼ��һ���ٶȼ���
        //myRididbody2D.velocity = myDirection * mySpeed;

        //this.transform.right = myDirection;

        
        if (Time.time > myKillTime)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D g_collision)
    {
        if (g_collision.gameObject == myOrigin)
            return;
        if (g_collision.GetComponent<CS_Enemy>() == true && myOrigin.GetComponent<CS_Enemy>() == true)
            return;
        if (g_collision.GetComponent<CS_Bullet>() == true)
            return;
        if (g_collision.GetComponent<CS_Player>() == true)
        {
            g_collision.GetComponent<CS_Player>().TakeDamage(1);
        }
        if (g_collision.GetComponent<CS_Boss>() == true)
        {
            g_collision.GetComponent<CS_Boss>().TakeDamage(1);
        }
        if (g_collision.GetComponent<CS_Enemy>() == true)
        {
            g_collision.gameObject.SetActive(false);//Ϊ�β���destroy��setactive������������ԣ�������ɼ���
        }
        
        Destroy(this.gameObject);
    }
}
