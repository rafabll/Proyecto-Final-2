using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Vector3 InitialPos = new Vector3(-28, 0, 1);

    public float PlayerHP = 100f;
    public Animator animator;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayer;
    public float attackDmg = 40f;
    

    public GameObject SpawnPoint;
    public LayerMask RayMask;

    //Variables de velocidad.
    private float speed = 5f;
    private float turnSpeed = 150f;
    private float sprintSpeed = 3f;       
    private Rigidbody playerRigidbody;
    //Eje de Rotacion.
    private float horizontalInput;
    
    //BALA Lanzada.
    public GameObject BalaPrefab;

    //Final del Juego.
    //private bool gameOver = false; 
   
    //Detector del click en camara
    public Camera cam;
  


    void Start()
    {
        transform.position = InitialPos;
        playerRigidbody = GetComponent<Rigidbody>();
        //PlayerHP = GetComponent<SpotLight.spotAngle>;
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("Isrunning", false);
        horizontalInput = Input.GetAxis("Horizontal");
        
        //Rotacion del personaje.
        transform.Rotate(Vector3.up * Time.deltaTime * turnSpeed * horizontalInput);

        //Movimiento hacia delante.
        if (Input.GetKey(KeyCode.W))
        {
            animator.SetBool("Isrunning", true);
            animator.SetBool("Issprinting", false);
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }

        //Movimiento hacia atras.
        if (Input.GetKey(KeyCode.S))
        {
            animator.SetBool("Isrunning", true);
            animator.SetBool("Issprinting", false);
            transform.Translate(Vector3.back * speed * Time.deltaTime);
        }

        //Sprint del personaje.
        if (Input.GetKey(KeyCode.LeftShift))
        {
            animator.SetBool("Isrunning", true);
            if (Input.GetKey(KeyCode.W))
            {
                animator.SetBool("Issprinting", true);
                transform.Translate(Vector3.forward * sprintSpeed * Time.deltaTime);
            }
            else if (Input.GetKey(KeyCode.S))
            {
                transform.Translate(Vector3.back * sprintSpeed * Time.deltaTime);
            }
            else
            {
                transform.Translate(Vector3.forward * sprintSpeed * Time.deltaTime);
            }
        }                
      
        if (Input.GetMouseButtonDown(1))
        {                        
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;           
            if (Physics.Raycast (ray, out hit, 100, RayMask))
            {                
                var projectile = Instantiate(BalaPrefab, SpawnPoint.transform.position, BalaPrefab.transform.rotation);
                projectile.transform.LookAt(hit.point);
                projectile.transform.rotation *= Quaternion.Euler(-90, 0, 0);
            }
           
        }
        if (Input.GetMouseButtonDown(0))
        {
            Attack();
        }
        if (PlayerHP <= 0f)
        {
            Destroy(gameObject);
            SceneManager.LoadScene("GameOver_Menu");
        }
    }
    void Attack()
    {
        animator.SetTrigger("Attack");
        Collider[] hitEnemy = Physics.OverlapSphere(attackPoint.position, attackRange, enemyLayer);

        foreach(Collider enemy in hitEnemy)
        {
            Debug.Log("We hit" + enemy.name);
            enemy.GetComponent<Enemy>().TakeDamage(attackDmg);
        }
    }    
    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}