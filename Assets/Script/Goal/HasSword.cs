using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Has Sword", menuName = "Goals/Has Sword")]
public class HasSword : Goal
{
    public int swordCount;
    public override bool IsGoalAcheived(AgentState ws)
    {
        return ws.inventory.sword >= swordCount;
    }

    public override int GetHeuristicValue(AgentState ws)
    {
        int result = 0;
        result += Mathf.Max(swordCount - ws.inventory.iron, 0) * 8;
        result += Mathf.Max(swordCount - ws.inventory.wood, 0) * 6;

        result += Mathf.Max(swordCount - ws.inventory.sword, 0) * 4;

        return result * (ws.skill.blacksmith ? 1 : 3);
    }

}
