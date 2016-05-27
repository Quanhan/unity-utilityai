using UnityEngine;
using System.Collections;

[CreateAssetMenu(fileName = "MoveToTarget", menuName = "AI/MoveToTarget", order = 1)]
public class AIMoveToTarget : AIThoughtScriptable {

    public float closestDistance;
    public float maxDistance;

    public override float ReturnWeight(GameObject owner)
    {
        // Get our target from the owner
        AIVision vision = owner.GetComponent<AIVision>();

        // Make sure we have a target
        if (vision.target == null)
        {
            return 100.0f;
        }

        // Find Distance
        float distance = Vector3.Distance(vision.target.transform.position, owner.transform.position);

        // Work out if we are too far away or too close.
        float norm = (distance - closestDistance) / (maxDistance - closestDistance);

        // Apply this to the curve we setup for the scriptable object to get urgency of distance. 
        float eval = urgency.Evaluate(norm) * 100.0f;

        return (eval);

        //return base.ReturnWeight(owner);
    }

    public override void OnExecuteThought(GameObject owner)
    {
        base.OnExecuteThought(owner);

        // Move the AI Navmesh Agent to the targets location
        owner.GetComponent<NavMeshAgent>().destination = owner.GetComponent<AIVision>().target.transform.position;
    }
}
