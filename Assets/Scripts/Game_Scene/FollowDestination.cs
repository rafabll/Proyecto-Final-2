using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowDestination : MonoBehaviour
{

	private UnityEngine.AI.NavMeshAgent zombie = null;
	public Transform destination = null;

	// Use this for initialization
	void Awake()
	{
		zombie = GetComponent<UnityEngine.AI.NavMeshAgent>();
	}	
	// Update is called once per frame
	void Update()
	{
		zombie.SetDestination(destination.position);
	}
}
