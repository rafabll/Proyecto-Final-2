using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class FollowDestination : MonoBehaviour
{

	private UnityEngine.AI.NavMeshAgent zombie = null;
	public Transform destination = null;
	public bool isChasing = false;
	public float maxDamage = 10.0f;
	private Transform playerTransform = null;
	private PlayerController PlayerScript;
	public int zona = 1;
	public Animator animator;

	// Use this for initialization
	void Awake()
	{
		zombie = GetComponent<UnityEngine.AI.NavMeshAgent>();
		PlayerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
		playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
	}	
	// Update is called once per frame
	void Update()
	{
		if (isChasing)
		{
			animator.SetBool("IsMoving", true);
			zombie.SetDestination(destination.position);

			if(zombie.remainingDistance <= zombie.stoppingDistance)
            {
				animator.SetTrigger("Attack");
				PlayerScript.PlayerHP -= maxDamage * Time.deltaTime;
			}
            else
            {
				animator.SetBool("IsMoving", true);
				zombie.SetDestination(destination.position);
			}
		}
	}
}
