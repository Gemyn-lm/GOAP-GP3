using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AgentStateUI : MonoBehaviour
{
    [SerializeField]
    AIAgent agent;

    [SerializeField]
    TextMeshProUGUI moneyText;
    [SerializeField]
    TextMeshProUGUI ironText;
    [SerializeField]
    TextMeshProUGUI woodText;
    [SerializeField]
    TextMeshProUGUI swordText;
    [SerializeField]
    TextMeshProUGUI blacksmithText;

    private void Start()
    {
        agent.onStateUpdated.AddListener(UpdateUI);
    }

    private void UpdateUI(AgentState state)
    {
        moneyText.text = state.inventory.money.ToString();
        ironText.text = state.inventory.iron.ToString();
        woodText.text = state.inventory.wood.ToString();
        swordText.text = state.inventory.sword.ToString();

        blacksmithText.text = state.skill.blacksmith ? "Yes" : "No";
    }
}
