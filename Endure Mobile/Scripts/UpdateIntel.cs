using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateIntel : MonoBehaviour
{
    public GameObject player;

    public GameObject parentObjNode;

    private UpdateObjective updateObjective;

    //private PlayerStats playerstats;

    private int intel_amount;

    public bool completedObj = false;

    // Start is called before the first frame update
    void Start()
    {
        parentObjNode = transform.parent.gameObject; // automatically get parent gameonject when put under a objective node; 

        updateObjective = parentObjNode.GetComponent<UpdateObjective>(); // gets the parent UpdateObjective Script type

        intel_amount = updateObjective.getIntelAmount(); // get intel amount

        //playerstats = player.GetComponent<PlayerStats>(); // add intel amount from here
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
