using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float maxHealth = 100f;
    private float currentHealth;
    public Animator enemyAnimator;
    public ParticleSystem explosionParticleSystem;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }  
    
    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        enemyAnimator.SetTrigger("Hurt");

        if(currentHealth <= 0f)
        {
            explosionParticleSystem.Play();
            Die();
        }
    }
    void Die()
    {        
        enemyAnimator.SetBool("IsDead", true);
        Debug.Log("Enemy died!");
        GetComponent<FollowDestination>().enabled = false;
        GetComponent<CapsuleCollider>().enabled = false;        
        GetComponent<AudioSource>().enabled = false;
        this.enabled = false;
    }

}
