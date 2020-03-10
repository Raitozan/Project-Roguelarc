using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
	public float gravity;
	Vector3 fallVelocity;

	bool isGrounded;
	LayerMask groundMask;

	CharacterController controller;
	GameObject playerModel;

	private void Awake()
	{
		controller = GetComponent<CharacterController>();
		playerModel = transform.Find("Model").gameObject;
		groundMask = LayerMask.NameToLayer("Ground");
	}
	
    void Update()
    {
		Move();
		CheckGround();
		Fall();
		Aim();
    }

	void Move()
	{
		Vector3 direction = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));

		direction = ToCameraSpace(direction);

		if (direction.magnitude >= 0.01f && direction.magnitude <= 0.2f)
		{
			direction = direction.normalized * 0.2f;
		}

		Vector3 velocity = direction * speed * Time.deltaTime;
		controller.Move(velocity);
	}

	void CheckGround()
	{
		if (controller.isGrounded)
		{
			isGrounded = true;
		}
		else
		{
			RaycastHit hit;
			if (Physics.Raycast(transform.position, Vector3.down, out hit, 0.1f, groundMask))
			{
				controller.Move(Vector3.down * hit.distance);
				isGrounded = true;
			}
			else
			{
				isGrounded = false;
			}
		}
	}

	void Fall()
	{
		if (isGrounded)
			fallVelocity = Vector3.zero;
		else
			fallVelocity.y += gravity * Time.deltaTime * Time.deltaTime;

		controller.Move(fallVelocity);
	}

	void Aim()
	{
		Vector3 aimDirection = new Vector3(Input.GetAxis("AimHorizontal"), 0.0f, Input.GetAxis("AimVertical"));
		aimDirection = ToCameraSpace(aimDirection);

		playerModel.transform.LookAt(playerModel.transform.position + aimDirection);
		playerModel.transform.localEulerAngles = new Vector3(0.0f, playerModel.transform.localEulerAngles.y, 0.0f);
	}

	Vector3 ToCameraSpace(Vector3 playerSpace)
	{
		Vector3 camForward = Camera.main.transform.forward;
		camForward.y = 0.0f;
		camForward = camForward.normalized;

		Vector3 camRight = Camera.main.transform.right;
		camRight.y = 0.0f;
		camRight = camRight.normalized;

		return playerSpace.x * camRight + playerSpace.z * camForward;
	}
}
