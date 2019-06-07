using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rlloop : MonoBehaviour
{
    public Vector3 position1 = new Vector3(0.0f, 0.0f, 0.0f);
    public Vector3 position2 = new Vector3(2.0f, 0.0f, 0.0f);

    Vector3 currentTargetDestination;

    public float distanceTolerance = 0.5f; //you can change the tolerance to whatever you need it to be

    void Start()
    {
        transform.position = position1; //set the initial position
        currentTargetDestination = position2;
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, currentTargetDestination, 5 * Time.deltaTime);

        if (Vector3.Distance(transform.position, currentTargetDestination) <= distanceTolerance)
        {
            //once we reach the current destination, set the other location as our new destination
            if (currentTargetDestination == position1)
            {
                currentTargetDestination = position2;
            }
            else
            {
                currentTargetDestination = position1;
            }
        }
    }
}
