﻿using System;
using System.Collections.Generic;
using System.Linq;
using _Scripts.Tiles;
using Assets.Scripts.DataStructures;
using Tarodev_Pathfinding._Scripts;
using Tarodev_Pathfinding._Scripts.Grid.Scriptables;
using UnityEngine;
//Allows us to use Lists.
using Random = UnityEngine.Random; //Tells Random to use the Unity Engine random number generator.


namespace Assets.Scripts
{
    public class BoardManager : MonoBehaviour
    {
        // Using Serializable allows us to embed a class with sub properties in the inspector.
        [Serializable]
        public class Count
        {
            public int minimum; //Minimum value for our Count class.
            public int maximum; //Maximum value for our Count class.


            //Assignment constructor.
            public Count(int min, int max)
            {
                minimum = min;
                maximum = max;
            }
        }

        public Dictionary<Vector2, NodePath> Tiles { get; private set; }

        public int columns = 10; //Number of columns in our game board.
        public int rows = 10; //Number of rows in our game board.
        public Count wallCount = new Count(5, 9); //Lower and upper limit for our random number of walls per level.
        public Count leverCount = new Count(3, 6); //Lower and upper limit for our random number of food items per level.
        
        public GameObject exit; //Prefab to spawn for exit.
        public GameObject floorTile; //Array of floor prefabs.
        public GameObject wallTile; //Array of wall prefabs.
        public GameObject leverTile; //Array of lever prefabs.
        public GameObject enemyTile; //Enemy Tile
        public GameObject outerWallTile; //Array of outer tile prefabs.

        public BoardInfo boardInfo;
        
        public const float TileSize = 1.0f;

        private CharacterBehaviour characterBehaviour;

        //public PathNode GetGridObject(int nodeX, int nodeY)
        //{
        //    //con el nodex y nodey, tenemos que ubicar donde esta la casilla, cual es. 
        //    return null;
        //}
        //public int GetHeight()
        //{ 
        //    return 0;
        //}
        //public int GetWidth()
        //{
        //    return 0;
        //}

        public void SetupScene(int seed, bool forPlanner, int enemyCount)
        {
            this.boardInfo = new BoardInfo(columns, rows, this);
            this.boardInfo.SetupBoard(seed, forPlanner, this.wallCount, this.leverCount, enemyCount);
        }


        public void GenerateMap()
        {
            this.boardInfo.CreateGameObject(this);
        }
        
    }


}