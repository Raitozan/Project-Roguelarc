using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowEditor : MonoBehaviour
{
	public DamageInfo damage;

	public float attackSpeed;

	public float arrowSpeed;

	private void OnValidate()
	{
		BowParameters.damage = damage;
		BowParameters.attackSpeed = attackSpeed;
		BowParameters.arrowSpeed = arrowSpeed;
	}
}
