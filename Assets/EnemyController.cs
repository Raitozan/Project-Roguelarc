using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum MovementType {ToPlayer, MaxDistToShoot, RandomMove};
public enum UpdateType {Continuous, ReachFirst};

public class EnemyController : MonoBehaviour
{
	MovementType movementType;
	UpdateType updateType;

	NavMeshAgent agent;

    void Awake()
    {
		agent = GetComponent<NavMeshAgent>();
    }

	private void Update()
	{

	}
}
