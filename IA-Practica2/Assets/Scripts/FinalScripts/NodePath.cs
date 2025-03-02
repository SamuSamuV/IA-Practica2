using _Scripts.Tiles;
using Assets.Scripts.DataStructures;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NodePath : NodeController
{
    public CellInfo cellInfo;
    public NodePath Connection { get; private set; }
    public List<NodePath> Neighbors { get; protected set; }

    public int gCost;
    public int hCost;
    public int fCost => gCost + hCost;

    public bool IsWalkable => this.cellInfo.Walkable;
    //public bool Walkable { get; private set; }
    public int GetDistance(NodePath other) //Manhattan Distance
    {
        int distanceX = Mathf.Abs(this.cellInfo.RowId - other.cellInfo.RowId);
        int distanceY = Mathf.Abs(this.cellInfo.ColumnId - other.cellInfo.ColumnId);
        return distanceX + distanceY;
    }
    
    public void SetConnection(NodePath nodeBase)
    {
        Connection = nodeBase;
    }
    public void SetG(int g)
    {
        gCost = g;
        Debug.Log(g);
    }

    public void SetH(int h)
    {
        hCost = h;
        Debug.Log(h);
    }
    public NodeController nodeController;
    public Vector2Int Position { get; private set; }
}
