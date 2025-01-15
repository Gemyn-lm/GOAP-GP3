using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Has Money", menuName = "Goals/Has Money")]
public class HasMoney : Goal
{
    public int moneyNeeded;
    public override bool IsGoalAcheived(AgentState ws)
    {
        return ws.inventory.money >= moneyNeeded;
    }

    public override int GetHeuristicValue(AgentState ws)
    {
        return  moneyNeeded - ws.inventory.money;
    }
}
