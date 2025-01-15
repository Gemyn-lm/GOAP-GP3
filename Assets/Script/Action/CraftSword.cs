using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Craft Sword", menuName = "Action/Craft Sword")]
public class CraftSword : Action
{
    public int costIfTrained, costIfNotTrained;

    public int ironNeeded, woodNeeded;
    public override int SimulateAction(ref AgentState state)
    {
        if (state.inventory.iron >= ironNeeded && state.inventory.wood >= woodNeeded)
        {
            Vector3 forgePos = WorldManager.Instance.GetNearestForge();
            int travelCost = ((int)Vector3.Distance(forgePos, state.position)) / 4;
            state.position = forgePos;
            state.inventory.iron -= ironNeeded;
            state.inventory.wood -= woodNeeded;
            state.inventory.sword += 1;
            return state.skill.blacksmith ? costIfTrained + travelCost: costIfNotTrained + travelCost;
        }
        else
        {
            return -1;
        }

    }

    public override IEnumerator DoAction(AIAgent agent)
    {
        while (Vector3.Distance(agent.transform.position, WorldManager.Instance.GetNearestForge()) > 2f)
        {
            agent.MoveToward(WorldManager.Instance.GetNearestForge());
            yield return null;
        }
        Debug.Log(agent.gameObject.name + " went to the forge");

        yield return new WaitForSeconds(1);
        Debug.Log(agent.name + " crafted a sword");
        SimulateAction(ref agent.state);
        agent.onStateUpdated.Invoke(agent.state);
    }
}

