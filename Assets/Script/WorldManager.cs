using System.Collections;
using System.Collections.Generic;
using UnityEditor.Search;
using UnityEngine;

public class WorldManager : MonoBehaviour
{
    private static WorldManager instance = null;
    public static WorldManager Instance => instance;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }
    }

    public GameObject shop;
    public GameObject forge;
    public GameObject mine;
    public GameObject workPlace;


    public Vector3 GetNearesShop()
    {
        return shop.transform.position;
    }

    public Vector3 GetNearestMine()
    {
        return mine.transform.position;
    }

    public Vector3 GetNearestForge()
    {
        return forge.transform.position;
    }

    public Vector3 GetNearestWorkPlace()
    {
        return workPlace.transform.position;
    }
}
