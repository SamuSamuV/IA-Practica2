using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinding
{
    private BoardManager<PathNode> grid;
    private List<PathNode> openList;
    private List<PathNode> closedList;

    public Pathfinding(int width, int height)
    {
        grid = new BoardManager<PathNode>(width, height, 10f, Vector3.zero, (BoardManager<PathNode> g, int x, int y) => new PathNode(g, x, y));
    }

    private List<Pathfinding> FindPath(int startX, int startY, int endX, int endY)
    {
        PathNode startNode = grid.GetGridObject(startX, startY);

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
        //startNode.gCost =
    }

    private int CalcuculateDistanceCost(PathNode a, PathNode b)
    {
        int XDistance = Mathf.Abs(a.x - b.x);
        int YDistance = Mathf.Abs(a.y - b.y);
        int remaining = Mathf.Abs(XDistance - YDistance);
    }
}
