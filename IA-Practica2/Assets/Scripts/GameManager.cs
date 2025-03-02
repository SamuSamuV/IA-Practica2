using Assets.Scripts.DataStructures;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

namespace Assets.Scripts
{
    public class GameManager : MonoBehaviour
    {

        public static GameManager instance = null;              //Static instance of GameManager which allows it to be accessed by any other script.
        public BoardManager BoardManager { get; set; }                      //Store a reference to our Board which will set up the level.
        public int seed=2016;
        public bool ForPlanner = false;
        public int numEnemies;

        private NodePath startNode, endNode;
        private CellInfo startCell;
        public List<GameObject> ActiveEnemies ;

        void Awake()
        {
            //Check if instance already exists
            if (instance == null)

                //if not, set instance to this
                instance = this;

            //If instance already exists and it's not this:
            else if (instance != this)

                //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
                Destroy(gameObject);

            //Sets this to not be destroyed when reloading scene
            DontDestroyOnLoad(gameObject);

            //Get a component reference to the attached BoardManager script
            this.BoardManager = GetComponent<BoardManager>();
        }

        public void Start()
        {
            var character= GameObject.Find("Character").GetComponent<CharacterBehaviour>();
            character.BoardManager= BoardManager;
            character.SetCurrentTarget(BoardManager.boardInfo.Exit);
            startCell = character.BoardManager.boardInfo.CellInfos[0, 0]; //Añadido, lo suponemos
            GetExit();
        }

        //Initializes the game for each level.
        public void InitGame()
        {
            ActiveEnemies = new List<GameObject>(numEnemies);
            //Call the SetupScene function of the BoardManager script, pass it current level number.
            BoardManager.SetupScene(this.seed, this.ForPlanner,numEnemies);
            BoardManager.GenerateMap();
        }
        private void GetExit()
        {
            endNode.cellInfo = BoardManager.boardInfo.Exit; //Se asigna la posición final
            startNode.cellInfo = startCell; //Se asigina la posición inicial

            endNode = new NodePath();
            startNode = new NodePath();

            var path = PathFinding.FindPath(startNode, endNode);
        }
    }
}
