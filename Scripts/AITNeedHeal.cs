/* Example
 * In this example the character sheet is checked to find the current hitpoints. This is then checked vs the curve to find out how urgent it is and returned to the thought processor.
 * 
 */

using UnityEngine;
using System.Collections;

[CreateAssetMenu(fileName = "NeedHeals", menuName = "AI/NeedHeals", order = 2)]
public class AITNeedHeal : AIThoughtScriptable {

    public override float ReturnWeight(GameObject owner)
    {
        CharacterSheet cs = owner.GetComponent<CharacterSheet>();
        float norm = (float)cs.currentHitPoints / (float)cs.maxHitPoints;
        float eval = urgency.Evaluate(norm) * 100.0f;
        return (Mathf.Round(eval));
    }

    public override void OnExecuteThought(GameObject owner)
    {
        base.OnExecuteThought(owner);
        CharacterSheet cs = owner.GetComponent<CharacterSheet>();
        //Find method of healing, do nothing if unable to heal.
        cs.skills[0].UseSkill(owner);
        
    }
}
