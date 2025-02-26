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

    public void PopulateNodesList() //Este método se llama para poblar la lista con todos los objetos que tengan el script de Nodos
    {
        nodosList.Clear(); //Limpiamos la lista para asegurarnos de que no haya nodos repetidos

        Nodes[] nodesArray = FindObjectsOfType<Nodes>(); //Obtenemos todos los objetos con el script Nodos en la escena

        foreach (var node in nodesArray)
        {
            nodosList.Add(node); //Agregamos todos los nodos encontrados a la lista
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
        PopulateNodesList();
    }
    void Update()
    {
        
    }
}
