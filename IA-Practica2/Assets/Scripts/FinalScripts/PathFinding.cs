using _Scripts.Tiles;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PathFinding : MonoBehaviour
{
    private static readonly Color PathColor = new Color(0.65f, 0.35f, 0.35f);
    private static readonly Color OpenColor = new Color(.4f, .6f, .4f);
    private static readonly Color ClosedColor = new Color(0.35f, 0.4f, 0.5f);
    public static List<NodePath> FindPath(NodePath startNode, NodePath endNode)
    {
        var toSearch = new List<NodePath>() { startNode };
        var processed = new List<NodePath>();

        while (toSearch.Any())
        {
            var current = toSearch[0];
            foreach (var t in toSearch)
                if (t.fCost < current.fCost || t.fCost == current.fCost && t.hCost < current.hCost) current = t;

            processed.Add(current);
            toSearch.Remove(current);


            if (current == endNode)
            {
                var currentPathTile = endNode;
                var path = new List<NodePath>();
                var count = 100;
                while (currentPathTile != startNode)
                {
                    path.Add(currentPathTile);
                    currentPathTile = currentPathTile.Connection;
                    count--;
                    if (count < 0) throw new Exception();
                }

                Debug.Log(path.Count);
                return path;
            }

            foreach (var neighbor in current.Neighbors.Where(t => t.IsWalkable && !processed.Contains(t)))
            {
                var inSearch = toSearch.Contains(neighbor);

                var costToNeighbor = current.gCost + current.GetDistance(neighbor);

                if (!inSearch || costToNeighbor < neighbor.gCost)
                {
                    neighbor.SetG(costToNeighbor);
                    neighbor.SetConnection(current);

                    if (!inSearch)
                    {
                        neighbor.SetH(neighbor.GetDistance(endNode));
                        toSearch.Add(neighbor);
                    }
                }
            }
        }
        return null;

    }
}
