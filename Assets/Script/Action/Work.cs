using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

[CreateAssetMenu(fileName = "Work", menuName = "Action/Work")]
public class Work : Action
{
    public int cost;
    public int moneyEarned;
    public override int SimulateAction(ref AgentState state)
    {
        Vector3 workPos = WorldManager.Instance.GetNearestWorkPlace();
        int travelCost = ((int)Vector3.Distance(workPos, state.position));
        state.position = workPos;
        state.inventory.money += moneyEarned;
        return cost + travelCost;
    }

    public override IEnumerator DoAction(AIAgent agent)
    {
        while(Vector3.Distance(agent.transform.position, WorldManager.Instance.GetNearestWorkPlace()) > 0.5f)
        {
            agent.MoveToward(WorldManager.Instance.GetNearestWorkPlace());
            yield return null;
        }
        Debug.Log(agent.gameObject.name + " went to work");

        yield return new WaitForSeconds(2f);
        Debug.Log(agent.gameObject.name + " worked");
        SimulateAction(ref agent.state);
        agent.onStateUpdated.Invoke(agent.state);
    }
}
