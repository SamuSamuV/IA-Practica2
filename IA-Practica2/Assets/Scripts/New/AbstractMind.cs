using Assets.Scripts;
using Assets.Scripts.DataStructures;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbstractMind : AbstractPathMind
{
    public override Locomotion.MoveDirection GetNextMove(BoardInfo boardInfo, CellInfo currentPos, CellInfo[] goals)
    {
        Locomotion.MoveDirection selectedDirection;
        bool validMove = false;

        var val = Random.Range(0, 4);
        if (val == 0) return Locomotion.MoveDirection.Up;
        if (val == 1) return Locomotion.MoveDirection.Down;
        if (val == 2) return Locomotion.MoveDirection.Left;
        return Locomotion.MoveDirection.Right;
    }

    public bool CheckifMoveIsValid(bool valid)
    {
        return valid;
    }
}
