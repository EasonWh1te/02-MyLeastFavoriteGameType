using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CS_EnemyShooting : MonoBehaviour
{
	[SerializeField] GameObject myBullet;
	[SerializeField] float myShootGap;
	private float myCD = 0;

	private void Update()
	{
		// check cool down
		if (myCD <= 0)
		{
			Shoot();
			myCD = myShootGap;
		}
		else
		{
			myCD -= Time.deltaTime;
		}
	}
	private void Shoot()
	{
		Vector2 t_shootDirection = Vector2.zero;
		if (this.transform.localScale.x > 0)
		{
			t_shootDirection = Vector2.right;
		}
		else 
		{
			t_shootDirection = Vector2.left;
		}
		//Debug.Log(t_shootDirection);

		GameObject t_bullet = Instantiate(myBullet, this.transform.position, Quaternion.identity);
		t_bullet.GetComponent<CS_Bullet>().Init(t_shootDirection, this.gameObject);
	}
}
