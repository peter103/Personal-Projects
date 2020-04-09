using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionObjectiveTracker : MonoBehaviour
{
    public GameObject finalObject;
    public int objectiveCount; 

    private UpdateObjective updateObjective;

    // Start is called before the first frame update
    void Start()
    {
        updateObjective = finalObject.GetComponent<UpdateObjective>();
        objectiveCount = transform.childCount - 1; 
    }

    // Update is called once per frame
    void Update()
    {
        if(objectiveCount <= 0)
        {
            updateObjective.allComplete();
        }
    }

    public void updateCurrentObjective()
    {
        objectiveCount--;
    }




}
