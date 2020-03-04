using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicAttack : MonoBehaviour
{
	public GameObject projectile;
	bool canShoot;

	void Start()
	{
		canShoot = true;
	}

	void Update()
	{
		if(Input.GetAxis("Shoot") >= 0.5f && canShoot)
		{
			canShoot = false;
			StartCoroutine(ShootCoroutine());
		}
	}


	IEnumerator ShootCoroutine()
	{
		Debug.Log("pew");
		yield return new WaitForSeconds(BowParameters.attackSpeed);
		canShoot = true;
	}
}
