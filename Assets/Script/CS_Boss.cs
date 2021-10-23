using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CS_Boss : MonoBehaviour
{
	[SerializeField] GameObject myBullet;
	[SerializeField] float myShootGap;
	private float myCD = 0;
	[SerializeField] float littleCD;

	[SerializeField] int bossMaxHealth = 4;
	private int bossCurrentHealth;
	[SerializeField] CS_Bar bossHealthBar;

	private void Start()
    {
		bossCurrentHealth = bossMaxHealth;
		//InvokeRepeating("Shoot", 0, 0.5f);
	}
    private void Update()
	{
		
		if (myCD <= 0)
		{
			Shoot();
			Invoke("Shoot", littleCD);
			//Invoke("Shoot", 0.5f);//???为什么第二次没有延迟
			myCD = myShootGap;
		}
		else
		{
			myCD -= Time.deltaTime;
		}
	}
	private void Shoot()
	{
		// get shoot direction
		Vector2 t_shootDirection = CS_Player.Instance.transform.position - this.transform.position;
		t_shootDirection = t_shootDirection.normalized;

		// shoot
		GameObject t_bullet = Instantiate(myBullet, this.transform.position, Quaternion.identity);
		t_bullet.GetComponent<CS_Bullet>().Init(t_shootDirection, this.gameObject);
	}

	public void TakeDamage(int g_damage)
	{
		bossCurrentHealth -= g_damage;
		
		if (bossCurrentHealth <= 0)
		{
			bossCurrentHealth = 0;
			this.gameObject.SetActive(false);
			CS_GameManager.Instance.CheckGameOver();
		}
		bossHealthBar.SetValue((float)bossCurrentHealth / bossMaxHealth);
	}
}
