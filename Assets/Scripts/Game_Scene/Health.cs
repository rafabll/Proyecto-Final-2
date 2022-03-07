using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
	[SerializeField]
	private float healthPoints = 100.0f;
	public float HealthPoints
	{
		get
		{
			return healthPoints;
		}

		set
		{
			healthPoints = value;

			if (healthPoints <= 0)
			{
				Destroy(gameObject);
			}

		}

	}		
}