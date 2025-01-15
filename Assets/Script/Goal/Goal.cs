using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Goal : ScriptableObject
{
    abstract public bool IsGoalAcheived(AgentState ws);
    abstract public int GetHeuristicValue(AgentState ws);
}
