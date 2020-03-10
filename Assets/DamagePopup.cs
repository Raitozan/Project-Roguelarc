using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DamagePopup : MonoBehaviour
{
	TextMeshPro text;
	Rigidbody rb;
	public float forceMagnitude;
	Animation anim;

	public void Launch(int damageNb)
	{
		transform.rotation = Camera.main.transform.rotation;

		text = GetComponent<TextMeshPro>();
		text.text = damageNb.ToString();

		rb = GetComponent<Rigidbody>();
		float x = Random.Range(0.05f, 0.5f);
		Vector3 force = new Vector3(x, 1.0f, 0.0f);
		force = force.normalized;
		rb.AddForce(force * forceMagnitude, ForceMode.Impulse);

		anim = GetComponent<Animation>();
		anim.Play();
		Destroy(gameObject, anim.clip.length);
	}
}
