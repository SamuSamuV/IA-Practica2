using Assets.Scripts.DataStructures;
using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Experimental.GraphView;

public class NodosController : MonoBehaviour
{
    public List<Nodes> nodosList = new List<Nodes>();
    public List<GameObject> obstacleList = new List<GameObject>();
    public List<GameObject> itemsList = new List<GameObject>();
    public List<GameObject> enemyList = new List<GameObject>();

    public void PopulateNodesList()
    {
        nodosList.Clear();

        Nodes[] nodesArray = FindObjectsOfType<Nodes>(); 

        foreach (var node in nodesArray)
        {
            nodosList.Add(node); 
        }
    }
    public void PopulateObstaclesList() 
    {
        obstacleList.Clear();

        GameObject[] obstacleArray = GameObject.FindGameObjectsWithTag("Wall");

        foreach (var obstacle in obstacleArray)
        {
            obstacleList.Add(obstacle);
        }
    }
    public void PopulateItemsList()
    {
        itemsList.Clear();

        GameObject[] itemArray = GameObject.FindGameObjectsWithTag("Item");

        if (itemArray.Length != 0)
        {
            foreach (var item in itemArray)
            {
                itemsList.Add(item);
            }
        }
    }
    public void PopulateEnemyList()
    {
        enemyList.Clear();

        GameObject[] enemyArray = GameObject.FindGameObjectsWithTag("Enemy");

        if (enemyArray.Length != 0)
        {
            foreach (var enemy in enemyArray)
            {
                enemyList.Add(enemy);
            }
        }
    }

    public void PopulateAllLists()
    {
        PopulateNodesList();
        PopulateObstaclesList();
        PopulateItemsList();
        PopulateEnemyList();
    }
    private void Start()
    {
        PopulateAllLists();
    }
    void Update()
    {
        
    }
}
