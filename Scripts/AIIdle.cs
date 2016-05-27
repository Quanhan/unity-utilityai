using UnityEngine;
using System.Collections;

[CreateAssetMenu(fileName = "Idle", menuName = "AI/Idle", order = 0)]
public class AIIdle : AIThoughtScriptable {

    public override float ReturnWeight(GameObject owner)    
    {
        //base.OnExecuteThought(owner);
        AIVision vision = owner.GetComponent<AIVision>();

        if (vision.target == null)
        {
            // have no target then we are 25% to be idleing. This is a bit basic but works in the example.
            return 25f;
        } else
        {
            // Have target so no longer idle. 
            return 100f;
        }

    }
}
