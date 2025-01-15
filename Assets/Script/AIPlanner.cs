using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class AIPlanner : MonoBehaviour
{
    public Goal goal;

    [SerializeField]
    List<Action> actions = new List<Action>();

    //public List<ActionNode> rootNodes = new List<ActionNode>();

    public List<ActionNode> taskList = new List<ActionNode>();
    int currentBestCost;


    [System.Serializable]
    public class ActionNode
    {
        public Action action;
        public ActionNode parent;
        public AgentState nodeState;
        public int cost;
        public int fCost;
        public int depth;
    }


    public void BuildActionPlan(AgentState state)
    {
        currentBestCost = int.MaxValue;
        BuildActionTree(null, state, 999);
    }

    //private void BuildActionTree(ActionNode parent, AgentState simulatedState, int depth = 0)
    //{
    //    foreach(Action action in actions)
    //    {
    //        AgentState currentState = simulatedState;

    //        ActionNode newNode = new ActionNode();
    //        newNode.action = action;
    //        newNode.cost = action.SimulateAction(ref currentState);

    //        if (newNode.cost == -1)
    //        {
    //            continue;
    //        }

    //        if (parent != null)
    //            newNode.cost += parent.cost;

    //        newNode.nodeState = currentState;
    //        newNode.parent = parent;


    //        if (goal.IsGoalAcheived(currentState))
    //        {
    //            if(newNode.cost < currentBestCost)
    //            {
    //                currentBestCost = newNode.cost;
    //                taskList.Clear();
    //                BuildActionList(newNode);
    //            }
    //            continue;
    //        }

    //        if(depth < maxDepth)
    //            BuildActionTree(newNode, currentState, depth + 1);
    //    }
    //}

    private void BuildActionTree(ActionNode parent, AgentState simulatedState, int maxStep = int.MaxValue)
    {
        List<ActionNode> open = new List<ActionNode>();
        List<ActionNode> close = new List<ActionNode>();

        // Init starting position
        ActionNode start = new ActionNode();
        start.parent = null;
        start.nodeState = simulatedState;
        start.cost = 0;
        start.fCost = goal.GetHeuristicValue(simulatedState);
        start.action = null;
        start.depth = 0;
        open.Add(start);

        int stepCount = 0;

        while(stepCount < maxStep || open.Count == 0)
        {
            ActionNode current = FindLowestFCost(open);
            open.Remove(current);
            close.Add(current);


            foreach(Action action in actions)
            {
                stepCount++;

                ActionNode neighbour = new ActionNode();
                try
                {
                    neighbour.action = action;
                    neighbour.nodeState = current.nodeState;
                    neighbour.parent = current;
                    neighbour.cost = neighbour.action.SimulateAction(ref neighbour.nodeState);
                    neighbour.cost += current.cost;
                    neighbour.depth = current.depth + 1;
                }
                catch
                {
                    print(current);
                }
                

                if (neighbour.cost == -1 || ActionNodeInList(close, neighbour) != null)
                    continue;


                if (goal.IsGoalAcheived(neighbour.nodeState))
                {
                    print("goal acheived in " + stepCount + " steps !");
                    BuildActionList(neighbour);
                    return;
                }

                ActionNode neighbourInOpen = ActionNodeInList(open, neighbour);

                if (neighbourInOpen == null || neighbourInOpen.cost > neighbour.cost)
                {
                    neighbour.fCost += neighbour.cost + goal.GetHeuristicValue(neighbour.nodeState);
                    
                    if (neighbourInOpen != null)
                    {
                        open.Remove(neighbourInOpen);
                    }
                    open.Add(neighbour);
                }
                
            }
        }

        ActionNode bestNode = FindLowestFCost(close);
        BuildActionList(bestNode);
    }

    private ActionNode ActionNodeInList(List<ActionNode> list, ActionNode node)
    {
        foreach(ActionNode element in list)
        {
            if(element.nodeState == node.nodeState)
            {
                return element;
            }
        }
        return null;
    }

    private ActionNode FindLowestFCost(List<ActionNode> open)
    {
        ActionNode result = null;
        int lowestFCost = int.MaxValue;
        foreach (ActionNode node in open)
        {
            if (node.fCost < lowestFCost)
            {
                result = node;
                lowestFCost = node.fCost;
            }
        }
        return result;
    }

    private void BuildActionList(ActionNode currentNode)
    {
        if(currentNode.parent != null)
        {
            taskList.Insert(0, currentNode);
            BuildActionList(currentNode.parent);
        }
    }
}
