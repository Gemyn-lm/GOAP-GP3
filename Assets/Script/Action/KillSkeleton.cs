using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Kill Skeleton", menuName = "Action/Kill Skeleton")]
public class KillSkeleton : Action
{
    public int cost;
    public int moneyEarned;
    public override int SimulateAction(ref AgentState state)
    {
        if(state.inventory.sword >= 1)
        {
            Vector3 minePos = WorldManager.Instance.GetNearestMine();
            int travelCost = ((int)Vector3.Distance(minePos, state.position));
            state.position = minePos;
            state.inventory.money += moneyEarned;
            return cost + travelCost;
        }
        else
        {
            return -1;
        }
        
    }

    public override IEnumerator DoAction(AIAgent agent)
    {
        while (Vector3.Distance(agent.transform.position, WorldManager.Instance.GetNearestMine()) > 0.5f)
        {
            agent.MoveToward(WorldManager.Instance.GetNearestMine());
            yield return null;
        }
        Debug.Log(agent.gameObject.name + " went to the mine");

        yield return new WaitForSeconds(2f);
        Debug.Log(agent.gameObject.name + " defeated some skeletons");
        SimulateAction(ref agent.state);
        agent.onStateUpdated.Invoke(agent.state);
    }
}
