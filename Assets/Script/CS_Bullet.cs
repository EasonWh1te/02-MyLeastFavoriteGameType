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
        //为何要实时更新速度？
        //1.可以用Kinematic属性？如果有问题可以改回Dynamic 2.可以关闭子弹重力，只初始化一次速度即可
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
            g_collision.gameObject.SetActive(false);//为何不用destroy？setactive是设置其可用性，不是其可见性
        }
        
        Destroy(this.gameObject);
    }
}
