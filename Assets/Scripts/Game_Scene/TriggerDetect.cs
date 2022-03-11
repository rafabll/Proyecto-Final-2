using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerDetect : MonoBehaviour
{


    private List<FollowDestination> followDestinations = new List<FollowDestination>();
    private FollowDestination followDestination;
    public int zone = 1;
    // Start is called before the first frame update
    void Start()
    {
        followDestination = GetComponent<FollowDestination>();

        foreach(FollowDestination fd in FindObjectsOfType<FollowDestination>())
        {
            if(fd.zona == this.zone)
            {
                followDestinations.Add(fd);
            }
        }



    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider collision)
    {
        Debug.Log("Entrado en trigger");
        if (collision.gameObject.tag == "Player")
        {
            //FindObjectOfType(followdestination.zona);            
            Debug.Log("Cuidado");
            foreach(FollowDestination fd in followDestinations)
            {
                fd.isChasing = true;
            }
        }
    }
}
