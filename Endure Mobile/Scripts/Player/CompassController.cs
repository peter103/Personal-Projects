using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompassController : MonoBehaviour
{

    public GameObject pointer;
    
    public GameObject player;
    
    public RectTransform compassLine;

    public List<GameObject> objectives;

    private bool next = false; 

    RectTransform rect;

    private int size = 0;   

    private int iterate = 0;

    private GameObject target;

    private UpdateObjective updateObj; 

    void Start()
    {
        rect = pointer.GetComponent<RectTransform>();
        size = objectives.Count; // Get the size of the list.

        // The controller will always begin with element 0 or the first objective.

        target = objectives[iterate];

        updateObj = target.GetComponent<UpdateObjective>();

        iterate++;
    }

    void Update()
    {

        if(objectives != null)
        { 
            if (iterate < size && next)
            {
                target = objectives[iterate];
                updateObj = target.GetComponent<UpdateObjective>();
                iterate++;
                next = false;
            }
        }
        Vector3[] v = new Vector3[4];
        compassLine.GetLocalCorners(v);
            
        float pointerScale = Vector3.Distance(v[1], v[2]); //both bottom corners

        Vector3 direction = target.transform.position - player.transform.position;
        
        float angleToTarget = Vector3.SignedAngle(player.transform.forward,
                                                                    direction,
                                                                player.transform.up);

        angleToTarget = Mathf.Clamp(angleToTarget, -90, 90) / 180.0f * pointerScale;

        rect.localPosition = new Vector3(angleToTarget, rect.localPosition.y, rect.localPosition.z);
        
    }
    public UpdateObjective getCurrentObjective()
    {
        return updateObj;
    }

    // Decreasing amount of intels in an objective
    public void decrementCurrentObjective()
    {
        updateObj.minusIntelAmount();
    }

    public void GoToNextObjective()
    {
        next = true;
    }
}
