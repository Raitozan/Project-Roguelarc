using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DamageType { Direct, DOT, AOE, DOTAOE }

[System.Serializable]
public struct DamageInfo
{
	public DamageType type;
	public int damageAmount;
	public float dotDuration;
	public float aoeRange;
}

public class Destroyable : MonoBehaviour
{
	public int healthPoints;

	public bool showDamagePopup;

	public void TakeDamage(DamageInfo dmg)
	{
		switch(dmg.type)
		{
			case DamageType.Direct:
				healthPoints -= dmg.damageAmount;
				break;
			case DamageType.DOT:
				break;
			case DamageType.AOE:
				break;
			case DamageType.DOTAOE:
				break;
		}

		if (healthPoints <= 0)
			Destroy(gameObject);
	}
}
