using UnityEngine;
using System.Collections;

public class AIThoughtScriptable : ScriptableObject {
    
    public string typeOfThought;
    public AnimationCurve urgency;

    public virtual void OnExecuteThought(GameObject owner)
    {
        
    }

    public virtual float ReturnWeight(GameObject owner)
    {
        return 100.0f;
    }
}
