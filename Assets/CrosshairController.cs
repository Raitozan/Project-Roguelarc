using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrosshairController : MonoBehaviour
{
	GameObject player;
	Vector3 previousPlayerPos;

	public GameObject midPoint;

	public float speed;
	public float maxDistance;

	public float gravity;
	Vector3 fallVelocity;

	bool isGrounded;
	LayerMask groundMask;

	CharacterController controller;

	private void Awake()
	{
		controller = GetComponent<CharacterController>();
		groundMask = LayerMask.NameToLayer("Ground");
	}

	private void Start()
	{
		player = GameManager.manager.player;
		previousPlayerPos = player.transform.position;
	}

	void Update()
	{
		MimicPlayer();
		Move();
		CheckGround();
		Fall();

		midPoint.transform.position = player.transform.position + ((transform.position - player.transform.position) / 2.0f);
	}

	void MimicPlayer()
	{
		Vector3 playerMovement = player.transform.position - previousPlayerPos;
		controller.Move(playerMovement);
		previousPlayerPos = player.transform.position;
	}

	void Move()
	{
		Vector3 direction = new Vector3(Input.GetAxis("AimHorizontal"), 0.0f, Input.GetAxis("AimVertical"));

		direction = ToCameraSpace(direction);

		if (direction.magnitude >= 0.01f && direction.magnitude <= 0.2f)
		{
			direction = direction.normalized * 0.2f;
		}

		Vector3 velocity = direction * speed * Time.deltaTime;
		CheckDistance(ref velocity);

		controller.Move(velocity);
	}

	void CheckDistance(ref Vector3 velocity)
	{
		if(Vector3.Distance(player.transform.position, transform.position + velocity) > maxDistance)
		{
			Vector3 toCrosshair = (transform.position - player.transform.position).normalized;
			Vector3 fixedPos = player.transform.position + toCrosshair * maxDistance;
			velocity = fixedPos - transform.position;
		}
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
