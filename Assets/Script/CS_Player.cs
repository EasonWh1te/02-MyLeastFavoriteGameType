using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CS_Player : MonoBehaviour
{
    private static CS_Player instance = null;
    public static CS_Player Instance { get { return instance; } }

    [SerializeField] Rigidbody2D myRigidbody2D;
    [SerializeField] float mySpeed;
    [SerializeField] float jumpSpeed;

    [SerializeField] GameObject myBullet;

    private bool isJumping = false;

    [SerializeField] int myMaxHealth = 4;
    private int myCurrentHealth;
    [SerializeField] CS_Bar myHealthBar;

    public static bool canShoot = false;
    

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

    private void Start()
    {
        myCurrentHealth = myMaxHealth;
    }

    private void Update()
    {
        Vector2 t_moveSpeed = myRigidbody2D.velocity;
        t_moveSpeed.x = 0;

        if (Input.GetKey(KeyCode.A))
        {
            t_moveSpeed.x -= mySpeed;
        }
        if (Input.GetKey(KeyCode.D))
        {
            t_moveSpeed.x += mySpeed;
        }
        if (Input.GetKeyDown(KeyCode.Space) && isJumping == false)
        {
            t_moveSpeed.y = jumpSpeed;
            isJumping = true;

            this.transform.SetParent(null);
        }

        myRigidbody2D.velocity = t_moveSpeed;

        if (Input.GetKeyDown(KeyCode.J) && canShoot == true)
        {
            GameObject t_bullet = Instantiate(myBullet, this.transform.position, Quaternion.identity);

            Vector2 t_bulletDirection = Vector2.zero;
            if (this.transform.localScale.x > 0)
            {
                t_bulletDirection = Vector2.right;
            }
            else
            {
                t_bulletDirection = Vector2.left;
            }
            t_bullet.GetComponent<CS_Bullet>().Init(t_bulletDirection, this.gameObject);
        }

        if (t_moveSpeed.x < 0)
        {
            this.transform.localScale = new Vector2(-1, 1);
        }
        else if (t_moveSpeed.x > 0)
        {
            this.transform.localScale = new Vector2(1, 1);
        }
    }

    public void TakeDamage(int g_damage)
    {
        myCurrentHealth -= g_damage;

        // check player dead
        if (myCurrentHealth <= 0)
        {
            myCurrentHealth = 0;
            this.gameObject.SetActive(false);
            //CS_GameManager.Instance.CheckGameOver(); Ã÷ÈÕ²¹È«
        }
         
        // update display
        myHealthBar.SetValue((float)myCurrentHealth / myMaxHealth);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (this.transform.position.y > collision.collider.transform.position.y)
        {
            isJumping = false;

            if (collision.gameObject.GetComponent<CS_MovingPlatform>() != null)
            {
                this.transform.SetParent(collision.transform);
            }
        }
    }


    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<CS_MovingPlatform>() != null)
        {
            this.transform.SetParent(null);
        }
    }
}
