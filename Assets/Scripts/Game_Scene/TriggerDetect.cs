using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerDetect : MonoBehaviour
{
    private FollowDestination followDestination;
    public int zone = 1;
    // Start is called before the first frame update
    void Start()
    {
        followDestination = GetComponent<FollowDestination>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            followDestination.isChasing = true;
            Debug.Log("Cuidado");
        }
    }
}
