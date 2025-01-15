using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Buy Iron", menuName = "Action/Buy Iron")]
public class BuyIron : Action
{
    public int cost;

    public int moneyNeeded;
    public override int SimulateAction(ref AgentState state)
    {
        if (state.inventory.money > moneyNeeded)
        {
            Vector3 shopPos = WorldManager.Instance.GetNearesShop();
            int travelCost = ((int)Vector3.Distance(shopPos, state.position)) / 4;
            state.position = shopPos;
            state.inventory.money -= moneyNeeded;
            state.inventory.iron += 1;
            return cost + travelCost;
        }
        else
        {
            return -1;
        }

    }

    public override IEnumerator DoAction(AIAgent agent)
    {
        while (Vector3.Distance(agent.transform.position, WorldManager.Instance.GetNearesShop()) > 3f)
        {
            agent.MoveToward(WorldManager.Instance.GetNearesShop());
            yield return null;
        }
        Debug.Log(agent.gameObject.name + " went to the shop");

        yield return new WaitForSeconds(1f);
        Debug.Log(agent.gameObject.name + " bought iron");
        SimulateAction(ref agent.state);
        agent.onStateUpdated.Invoke(agent.state);
    }
}
