using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Train BlackSmith Skills", menuName = "Action/Train BlackSmith Skills")]
public class TrainBlackSmith : Action
{
    public int cost;

    public int moneyNeeded;
    public override int SimulateAction(ref AgentState state)
    {
        if(state.inventory.money >= moneyNeeded && !state.skill.blacksmith)
        {
            Vector3 forgePos = WorldManager.Instance.GetNearestForge();
            int travelCost = ((int)Vector3.Distance(forgePos, state.position)) / 4;
            state.position = forgePos;
            state.skill.blacksmith = true;
            state.inventory.money -= moneyNeeded;
            return cost + travelCost;
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

        yield return new WaitForSeconds(1f);
        Debug.Log(agent.name + " trained his blacksmith skills");
        SimulateAction(ref agent.state);
        agent.onStateUpdated.Invoke(agent.state);
    }
}
