﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UpdateObjective : MonoBehaviour
{



    public GameObject CompassManager;
    public GameObject EndMissionScreen;

    public GameObject player;

    private CompassController compass_controller;

    public bool collectIntel = false; // set true if there's intel to collect

    public int amountOfIntelNeeded = 1;

    public bool endMission = false;
    public bool complete = false;

    private GameObject objCounter;
    private MissionObjectiveTracker tracker; 

    void Start()
    {
        amountOfIntelNeeded = transform.childCount; // Count amount of child nodes to determine the intel files needed for that objective Zone.
        EndMissionScreen.SetActive(false);

        objCounter = transform.parent.gameObject;
        tracker = objCounter.GetComponent<MissionObjectiveTracker>();
    }

    void OnTriggerEnter(Collider hit)
    {
        // Utilize the compass manager gameobject and use its scripts to update the next objective.
        compass_controller = CompassManager.GetComponent<CompassController>();

        if (hit.tag == "Player")
        {
            if (complete)
            {
                EndMissionScreen.SetActive(true);
            }
            if (!collectIntel && amountOfIntelNeeded == 0 && !endMission)
            {
                tracker.updateCurrentObjective();
                compass_controller.GoToNextObjective();
                Destroy(this.gameObject);
            }

        }
    }

    // Update is called once per frame
    void Update()
    {
        if (amountOfIntelNeeded <= 0 && collectIntel) // check on whether an objective has been done. 
        {
            collectIntel = false;
            tracker.updateCurrentObjective();
            compass_controller.GoToNextObjective();
            Destroy(this.gameObject);
        }

    }

    public void CollectedIntel()
    {
        collectIntel = false;
    }

    public void allComplete()
    {
        complete = true;
    }

    public void returnToMenu(bool decide)
    {
        if(decide)
        {
            SceneManager.LoadScene("MainMenu");
            Destroy(this.gameObject);
        }
    }

    public int getIntelAmount()
    {
        return amountOfIntelNeeded;
    }

    public void minusIntelAmount()
    {
        if (amountOfIntelNeeded > 0)
        {
            amountOfIntelNeeded--;
        }
        else
        {
            amountOfIntelNeeded = 0;
        }
    }
}
