using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowEditor : MonoBehaviour
{
	public DamageType damageType;
	public int damageAmount;

	public float attackSpeed;

	public float projectileSpeed;

	private void OnValidate()
	{
		BowParameters.damageType = damageType;
		BowParameters.damageAmount = damageAmount;
		BowParameters.attackSpeed = attackSpeed;
		BowParameters.projectileSpeed = projectileSpeed;
	}
}
