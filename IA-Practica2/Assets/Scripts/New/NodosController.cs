using Assets.Scripts.DataStructures;
using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodosController : MonoBehaviour
{
    public List<Nodos> nodosList = new List<Nodos>();

    public void PopulateNodosList() //Este método se llama para poblar la lista con todos los objetos que tengan el script de Nodos
    {
        nodosList.Clear(); //Limpiamos la lista para asegurarnos de que no haya nodos repetidos

        Nodos[] nodosArray = FindObjectsOfType<Nodos>(); //Obtenemos todos los objetos con el script Nodos en la escena

        foreach (var nodo in nodosArray)
        {
            nodosList.Add(nodo); //Agregamos todos los nodos encontrados a la lista
        }
    }
    private void Start()
    {

    }
    void Update()
    {
        
    }
}
