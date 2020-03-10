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

public class Destructible : MonoBehaviour
{
	public int healthPoints;

	[Header("Popup")]
	public bool showDamagePopup;
	public GameObject damagePopup;

	[Header("Shake")]
	public bool activateShake;
	public float shakeDuration;
	public float shakeStrength;

	[Header("Knockback")]
	public bool activateKnockback;

	public void TakeDamage(DamageInfo dmg)
	{
		switch(dmg.type)
		{
			case DamageType.Direct:
				healthPoints -= dmg.damageAmount;
				damageEffects(dmg);
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

	public void damageEffects(DamageInfo dmg)
	{
		if (showDamagePopup)
		{
			Vector3 instancePos = transform.position;
			instancePos.y = 2.0f;
			Instantiate(damagePopup, instancePos, Quaternion.identity).GetComponent<DamagePopup>().Launch(dmg.damageAmount);
		}

		if (activateShake)
			StartCoroutine(ShakeCoroutine(dmg));

	}

	IEnumerator ShakeCoroutine(DamageInfo dmg)
	{
		float endTime = Time.time + shakeDuration;
		GameObject model = transform.Find("Model").gameObject;
		Vector3 defaultPos = model.transform.position;

		while(Time.time < endTime)
		{
			model.transform.position = defaultPos;
			model.transform.position = model.transform.position + Random.insideUnitSphere * shakeStrength * Time.deltaTime;
			yield return new WaitForSeconds(0.05f);
		}

		model.transform.position = defaultPos;
	}
}
