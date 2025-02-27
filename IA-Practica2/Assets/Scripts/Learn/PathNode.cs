using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;
using Assets.Scripts.DataStructures;

public class PathNode
{
    private BoardManager grid;
    private CellInfo cellInfo;
    private PathNode parentNode;

    public int gCost;
    public int hCost;
    public int fCost => gCost + hCost;

    public PathNode cameFromNode;
    public int X => this.cellInfo.ColumnId;
    public int Y => this.cellInfo.RowId;

    public PathNode(BoardManager grid, CellInfo cell)
    {
        this.grid = grid;
        this.cellInfo = cell;
       
    }



    public override string ToString()
    {
        return X + "," + Y;
    }
}
