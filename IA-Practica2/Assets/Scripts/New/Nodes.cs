using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nodes : MonoBehaviour
{
    //Cada casillla tiene un nodo.
    //Como referencia al personaje: Calcular distancia origen, distancia a la casilla de fin y la suma de las dos.

    public Nodes Connection { get; private set; }
    public float G { get; private set; }
    public float H { get; private set; }
    public float F => G + H;

    public void SetConnection(Nodes nodes) => Connection = nodes;

    public void SetG(float g) => G = g;
    public void SetH(float h) => H = h;
}
