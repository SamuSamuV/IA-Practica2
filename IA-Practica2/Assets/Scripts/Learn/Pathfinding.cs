//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using Assets.Scripts;

//public class Pathfinding
//{
//    private const int MOVE_STRAIGHT_COST = 10;
//    //private const int MOVE_DIAGONAL_COST = 14;

//    private BoardManager grid;
//    private List<PathNode> openList;
//    private List<PathNode> closedList;

//    public Pathfinding(int width, int height)
//    {
//        grid = GameManager.instance.BoardManager;
//        //grid = new BoardManager<PathNode>(width, height, 10f, Vector3.zero, (BoardManager<PathNode> g, int x, int y) => new PathNode(g, x, y));
//    }

//    private List<Pathfinding> FindPath(int startX, int startY, int endX, int endY)
//    {
//        PathNode startNode = grid.GetGridObject(startX, startY);//posicion inicial de la partida
//        PathNode endNode = grid.GetGridObject(endX, endY);//posicion final de la partida

//        openList = new List<PathNode> { startNode };
//        closedList = new List<PathNode>();

//        for (int x = 0; x < grid.GetWidth(); x++)
//        {
//            for (int y = 0; y < grid.GetHeight(); y++)
//            {
//                PathNode pathNode = grid.GetGridObject(x, y);
//                pathNode.gCost = int.MaxValue;
//                //pathNode.CalculateFCost();
//                pathNode.cameFromNode = null;
//            }
//        }

//        startNode.gCost = 0;
//        startNode.hCost = CalculateDistanceCost(startNode, endNode);
//        //startNode.CalculateFCost();

//        while (openList.Count > 0)
//        {
//            PathNode currentNode = GetLowestFCostNode(openList);
//            if (currentNode == endNode)
//            {
//                //Reached final node
//                //return CalculatePath(endNode);

//            }

//            openList.Remove(currentNode);
//            closedList.Add(currentNode);

//            foreach (PathNode neighbourNode in GetNeighbourList(currentNode))
//            {
//                if (closedList.Contains(neighbourNode)) continue;

//                int tentativeGCost = currentNode.gCost + CalculateDistanceCost(currentNode, neighbourNode);
//                if (tentativeGCost < neighbourNode.gCost)
//                {
//                    neighbourNode.cameFromNode = currentNode;
//                    neighbourNode.gCost = tentativeGCost;
//                    neighbourNode.hCost = CalculateDistanceCost(neighbourNode, endNode);
//                    //neighbourNode.CalculateFCost();

//                    if (!openList.Contains(neighbourNode))
//                    {
//                        openList.Add(neighbourNode);
//                    }
//                }
//            }
//        }

//        //Out of nodes on the openList
//        return null;
//    }

//    private List<PathNode> GetNeighbourList(PathNode currentNode)
//    {
//        List<PathNode> neighbourList = new List<PathNode>();

//        if (currentNode.X - 1 >= 0)
//        {
//            // Left
//            neighbourList.Add(GetNode(currentNode.X - 1, currentNode.Y));
//            // Left Down
//            if (currentNode.Y - 1 >= 0) 
//                neighbourList.Add(GetNode(currentNode.X - 1, currentNode.Y - 1));
//            // Left Up
//            if (currentNode.Y + 1 < grid.GetHeight()) 
//                neighbourList.Add(GetNode(currentNode.X - 1, currentNode.Y + 1));
//        }
        
//        if (currentNode.X + 1 < grid.GetWidth())
//        {
//            // Right
//            neighbourList.Add(GetNode(currentNode.X + 1, currentNode.Y));
//            // Right Down
//            if (currentNode.Y - 1 >= 0) 
//                neighbourList.Add(GetNode(currentNode.X + 1, currentNode.Y - 1));
//            // Right Up
//            if (currentNode.Y + 1 < grid.GetHeight()) 
//                neighbourList.Add(GetNode(currentNode.X + 1, currentNode.Y + 1));
//        }
        
//        // Down
//        if (currentNode.Y - 1 >= 0) 
//            neighbourList.Add(GetNode(currentNode.X, currentNode.Y - 1));
//        // Up
//        if (currentNode.Y + 1 < grid.GetHeight()) 
//            neighbourList.Add(GetNode(currentNode.X, currentNode.Y + 1));
        
//        return neighbourList;
        
//    }
//    public PathNode GetNode(int nodeX, int nodeY)
//    {
//        //nose 
//        return null;
//    }

//    //private List<PathNode> CalculatePath(PathNode endNode)
//    //{
//    //    List<PathNode> path = new List<PathNode>();
//    //    path.Add(endNode);
//    //    PathNode currentNode = endNode;
//    //    while (currentNode.cameFromNode != null)
//    //    {
//    //        path.Add(currentNode.cameFromNode);
//    //        currentNode = currentNode.cameFromNode;
//    //    }
//    //    path.Reverse();
//    //    return path;
//    //}

//    private int CalculateDistanceCost(PathNode a, PathNode b)
//    {
//        int XDistance = Mathf.Abs(a.X - b.X);
//        int YDistance = Mathf.Abs(a.Y - b.Y);
//        int remaining = Mathf.Abs(XDistance - YDistance);
//        return MOVE_STRAIGHT_COST * remaining;
//    }

//    private PathNode GetLowestFCostNode(List<PathNode> pathNodeList)
//    {
//        PathNode lowestFCostNode = pathNodeList[0];
//        for (int i = 1; i < pathNodeList.Count; i++)
//        {
//            if (pathNodeList[i].fCost < lowestFCostNode.fCost)
//            {
//                lowestFCostNode = pathNodeList[i];
//            }
//        }
//        return lowestFCostNode;
//    }
//}
