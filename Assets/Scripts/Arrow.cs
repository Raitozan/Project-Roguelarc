using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
	Vector3 previousPos;
	public float lifetime;
	public LayerMask hitmask;
	float speed;

	private void Start()
	{
		previousPos = transform.position;
		speed = BowParameters.arrowSpeed;
	}

	private void Update()
	{
		if(speed > 0.0f)
		{
			//move
			previousPos = transform.position;
			Vector3 velocity = transform.forward * speed;
			transform.position = transform.position + velocity * Time.deltaTime;

			//check collision
			Vector3 toNewPos = transform.position - previousPos;
			RaycastHit hit;
			if (Physics.Raycast(previousPos, toNewPos.normalized, out hit, toNewPos.magnitude, hitmask))
			{
				HandleCollision(hit.collider);
			}
			else if ((lifetime -= Time.deltaTime) <= 0.0f)
			{
				speed = 0.0f;
				Destroy(gameObject, 0.1f);
			}
		}
	}

	void HandleCollision(Collider other)
	{
		if(other.CompareTag("Destroyable") || other.CompareTag("Enemy"))
			other.GetComponent<Destroyable>().TakeDamage(BowParameters.damage);

		speed = 0.0f;
		Destroy(gameObject, 0.1f);
	}

}
