using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinding
{
    private const int MOVE_STRAIGHT_COST = 10;
    private const int MOVE_DIAGONAL_COST = 14;

    private BoardManager<PathNode> grid;
    private List<PathNode> openList;
    private List<PathNode> closedList;

    public Pathfinding(int width, int height)
    {
        grid = new BoardManager<PathNode>(width, height, 10f, Vector3.zero, (BoardManager<PathNode> g, int x, int y) => new PathNode(g, x, y));
    }

    private List<Pathfinding> FindPath(int startX, int startY, int endX, int endY)
    {
        PNode startNode = grid.GetGridObject(startX, startY);
        PNode endNode = grid.GetGridObject(endX, endY);

        openList = new List<PathNode> { startNode };
        closedList = new List<PathNode>();

        for (int x = 0; x < grid.GetWidth(); x++)
        {
            for (int y = 0; y < grid.GetHeight(); y++)
            {
                PathNode pathNode = grid.GetGridObject(x, y);
                pathNode.gCost = int.MaxValue;
                pathNode.CalculateFCost();
                pathNode.cameFromNode = null;
            }
        }

        startNode.gCost = 0;
        startNode.hCost = CalcuculateDistanceCost(startNode, endNode);
        startNode.CalculateFCost();

        while(openList.Count > 0)
        {
            PathNode currentNode = GetLowestFCostNode(openList);
            if (currentNode != null)
            {
                //Reached final node
                return CalculatePath(endNode);
            }


        }
    }

    private int CalcuculateDistanceCost(PNode a, PNode b)
    {
        int XDistance = Mathf.Abs(a.x - b.x);
        int YDistance = Mathf.Abs(a.y - b.y);
        int remaining = Mathf.Abs(XDistance - YDistance);
        return MOVE_DIAGONAL_COST * Mathf.Min(XDistance, YDistance) + MOVE_STRAIGHT_COST * remaining;
    }

    private PathNode GetLowestFCostNode(List<PathNode> pathNodeList)
    {
        PathNode lowestFCostNode = pathNodeList[0];
        for (int i = 1; i < pathNodeList.Count; i++)
        {
            if (pathNodeList[i].fCost < lowestFCostNode.fCost)
            {
                lowestFCostNode = pathNodeList[i];
            }
        }
        return lowestFCostNode;
    }
}
