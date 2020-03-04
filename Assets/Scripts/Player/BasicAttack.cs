using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicAttack : MonoBehaviour
{
	public GameObject arrow;
	public Transform startPoint;
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
		Instantiate(arrow, startPoint.position, startPoint.rotation);
		yield return new WaitForSeconds(BowParameters.attackSpeed);
		canShoot = true;
	}
}
