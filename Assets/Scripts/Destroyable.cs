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
	public GameObject damagePopup;

	public void TakeDamage(DamageInfo dmg)
	{
		switch(dmg.type)
		{
			case DamageType.Direct:
				healthPoints -= dmg.damageAmount;
				if (showDamagePopup)
					Instantiate(damagePopup, transform.position + new Vector3(0.0f, 1.0f, 0.0f), Quaternion.identity).GetComponent<DamagePopup>().Launch(dmg.damageAmount);
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
