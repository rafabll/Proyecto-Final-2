using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    public float bulletDmg = 20f;
    
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 10);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * 30 * Time.deltaTime);
          
    }
    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            BulletHit();
        }
    }
    void BulletHit()
    {
        GetComponent<Enemy>().TakeDamage(bulletDmg);
    }
}
