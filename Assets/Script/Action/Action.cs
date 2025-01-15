using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Action : ScriptableObject
{

    // If the function returns -1, then it's not possible
    public abstract int SimulateAction(ref AgentState state);

    public abstract IEnumerator DoAction(AIAgent agent);
}



