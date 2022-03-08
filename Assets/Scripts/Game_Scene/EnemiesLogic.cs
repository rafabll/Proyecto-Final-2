using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemiesLogic : MonoBehaviour
{

	public enum ENEMY_STATE
	{
		CHASE,
		ATTACK
	};

	public ENEMY_STATE CurrentState
	{
		get { return CurrentState; }

		set
		{
			StopAllCoroutines();

			switch (CurrentState)
			{
				case ENEMY_STATE.CHASE:
					StartCoroutine(AIChase());
					break;

				case ENEMY_STATE.ATTACK:
					StartCoroutine(AIAttack());
					break;

			}

		}

	}

	private bool canMove;

	private UnityEngine.AI.NavMeshAgent theAgent = null;

	private Transform playerTransform = null;

	private Health playerHealth = null;

	public float maxDamage = 10.0f;

	private bool isChasing = false;

	void Awake()
	{
		theAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
		playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
		playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
	}

	// Use this for initialization
	void Start()
	{
		//CurrentState = AIChase;
	}

	/*
	public IEnumerator AIPatrol()
	{

		while (CurrentState == ENEMY_STATE.PATROL)
		{
			theLineSight.sensitivity = LineSight.SightSensitivity.STRICT;

			theAgent.Resume();
			canMove = false;
			

			while (theAgent.pathPending)
				yield return null;

			if (theLineSight.canSeeTarget)
			{
				theAgent.Stop();
				CurrentState = ENEMY_STATE.CHASE;
				yield break;
			}

			yield return null;

		}

	}
	*/
	void OnTriggerEnter(Collider collision)
	{
		if (collision.gameObject.tag == "Trigger")
		{
			isChasing = true;
			StartCoroutine(AIChase());
		}
	}
	
		public IEnumerator AIChase()
		{

			while (CurrentState == ENEMY_STATE.CHASE)
			{
				theAgent.Resume();
				theAgent.SetDestination(playerTransform.position);

				while (theAgent.pathPending)
					yield return null;

				if (theAgent.remainingDistance <= theAgent.stoppingDistance)
				{
					CurrentState = ENEMY_STATE.ATTACK;
					yield break;
				}
				yield return null;
			}
		}


		public IEnumerator AIAttack()
		{
			while (CurrentState == ENEMY_STATE.ATTACK)
			{

				theAgent.Resume();
				theAgent.SetDestination(playerTransform.position);

				while (theAgent.pathPending)
					yield return null;


				if (theAgent.remainingDistance > theAgent.stoppingDistance)
				{
					CurrentState = ENEMY_STATE.CHASE;
					yield break;
				}
				else
				{
					w
				}

				yield return null;
			}
		}
	
}
