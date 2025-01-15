using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct AgentState
{
    public Vector3 position;

    [System.Serializable]
    public struct Inventory
    {
        public int money;
        public int iron;
        public int wood;
        public int sword;
    }

    [System.Serializable]
    public struct Skill
    {
        public bool blacksmith;
    }

    public Inventory inventory;
    public Skill skill;

    public static bool operator== (AgentState a, AgentState b)
    {
        return (a.inventory.money == b.inventory.money
            && a.inventory.iron == b.inventory.iron
            && a.inventory.wood == b.inventory.wood
            && a.inventory.sword == b.inventory.sword
            && a.skill.blacksmith == b.skill.blacksmith
            && Vector3.Distance(a.position, b.position) < 2f);
    }

    public static bool operator !=(AgentState a, AgentState b)
    {
        return (a.inventory.money != b.inventory.money
            || a.inventory.iron != b.inventory.iron
            || a.inventory.wood != b.inventory.wood
            || a.inventory.sword != b.inventory.sword
            || a.skill.blacksmith != b.skill.blacksmith
            || Vector3.Distance(a.position, b.position) > 2f);
    }

    public override bool Equals(object obj)
    {
        return base.Equals(obj);
    }
}
