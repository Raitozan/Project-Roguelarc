using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public Vector3 direction;
	Rigidbody rb;

	private void Awake()
	{
		rb = GetComponent<Rigidbody>();
	}
	
	void Start()
    {
        
    }
	
    void Update()
    {
		Move();
    }

	void Move()
	{
		direction = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));

		Vector3 camForward = Camera.main.transform.forward;
		camForward.y = 0.0f;
		camForward = camForward.normalized;
		Vector3 camRight = Camera.main.transform.right;
		camRight.y = 0.0f;
		camRight = camRight.normalized;

		direction = (direction.x * camRight + direction.z * camForward);

		if (direction.magnitude >= 0.01f && direction.magnitude <= 0.2f)
		{
			direction = direction.normalized * 0.2f;
		}

		Vector3 velocity = direction * speed * Time.deltaTime;

		rb.MovePosition(transform.position + velocity);
		transform.LookAt(transform.position + direction);
		transform.localEulerAngles = new Vector3(0.0f, transform.localEulerAngles.y, 0.0f);

		Debug.Log(rb.velocity.magnitude);
	}
}
