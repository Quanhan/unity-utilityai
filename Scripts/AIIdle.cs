/*
 * Real simple example where the thought has no action. In this case if the actor has a target its urgency is 25% otherwise its 100% with no target.
 * 
 * 
 */

using UnityEngine;
using System.Collections;

[CreateAssetMenu(fileName = "Idle", menuName = "AI/Idle", order = 0)]
public class AIIdle : AIThoughtScriptable
{
    public override float ReturnWeight(GameObject owner)
    {
        NPCActor3D actor = owner.GetComponent<NPCActor3D>();
        if (actor.currentTarget == null)
        {
            return 25.0f;
        } else
        {
            return 100.0f;
        }
    }
}
