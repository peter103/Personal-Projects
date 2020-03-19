using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateObjective : MonoBehaviour
{



    public GameObject CompassManager;

    private CompassController compass_controller;

    private bool finishObj = false;


    void Start()
    {
       
    }

    void OnTriggerEnter(Collider hit)
    {
        // Utilize the compass manager gameobject and use its scripts to update the next objective.
        compass_controller = CompassManager.GetComponent<CompassController>();
        if (hit.tag == "Player")
        {
            compass_controller.GoToNextObjective();
            Destroy(this.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
