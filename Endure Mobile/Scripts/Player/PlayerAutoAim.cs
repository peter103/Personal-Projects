using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAutoAim : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject enemy;

    public GameObject fovStartPoint;


    public float lookSpeed = 200;

    public float maxAngle = 20;
    public float maxAngleReset = 40;

    public float smoothTime = 3.0f;

    private Quaternion lookAt;
    private Quaternion targetRotation;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (enemy != null && EnemyInFieldOfView(fovStartPoint))
        {
            Vector3 direction = enemy.transform.position - transform.position;

            // Rotate the current transform to look at the enemy
            targetRotation = Quaternion.LookRotation(direction);
            //lookAt = Quaternion.RotateTowards(transform.rotation, targetRotation, Time.deltaTime * lookSpeed);

            direction.y = transform.position.y;

            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * smoothTime);
        }
        else if (enemy != null && EnemyInFieldOfViewNoResetPoint(fovStartPoint))
        {
            return;
        }
    }

    bool EnemyInFieldOfView(GameObject looker)
    {

        Vector3 targetDir = enemy.transform.position - looker.transform.position;
        // gets the direction to the enemy.

        float angle = Vector3.Angle(targetDir, looker.transform.forward);
        // gets the angle based on the direction.

        if (angle < maxAngle)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    bool EnemyInFieldOfViewNoResetPoint(GameObject looker)
    {
        Vector3 targetDir = enemy.transform.position - looker.transform.position;
        float angle = Vector3.Angle(targetDir, looker.transform.forward);

        if (angle < maxAngleReset)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
