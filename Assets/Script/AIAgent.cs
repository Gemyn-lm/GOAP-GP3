using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

public class AIAgent : MonoBehaviour
{
    public float speed;

    AIPlanner planner;

    public AgentState state;

    public UnityEvent<AgentState> onStateUpdated;

    void Start()
    {
        planner = GetComponent<AIPlanner>();
        
    }


    IEnumerator ExecuteTask()
    {
        while (planner.taskList.Count > 0)
        {
            Debug.Log("Start Tasks, task left : " + planner.taskList.Count);
            yield return StartCoroutine(planner.taskList[0].action.DoAction(this));
            planner.taskList.RemoveAt(0);
        }

    }

    private void Update()
    {
        if(planner.taskList.Count == 0 && !planner.goal.IsGoalAcheived(state))
        {
            planner.BuildActionPlan(state);
            StartCoroutine(ExecuteTask());
        }
    }

    public void MoveToward(Vector3 target)
    {
        transform.position += (target - transform.position).normalized * speed * Time.deltaTime;
    }

}
