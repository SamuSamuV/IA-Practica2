using Assets.Scripts.DataStructures;
using UnityEngine;

namespace Assets.Scripts
{
    [RequireComponent(typeof(Locomotion))]
    public class CharacterBehaviour: MonoBehaviour
    {
        
        protected Locomotion LocomotionController;
        protected AbstractPathMind PathController;
        public BoardManager BoardManager { get; set; }
        protected CellInfo currentTarget;
        public float rayDistance = 1f;

        void Awake()
        {

            PathController = GetComponentInChildren<AbstractPathMind>();
            PathController.SetCharacter(this);
            LocomotionController = GetComponent<Locomotion>();
            LocomotionController.SetCharacter(this);

            

        }

        void Update()
        {
            if (BoardManager == null) return;
            if (LocomotionController.MoveNeed)
            {

                var boardClone = (BoardInfo)BoardManager.boardInfo.Clone();
                LocomotionController.SetNewDirection(PathController.GetNextMove(boardClone,LocomotionController.CurrentEndPosition(),new [] {this.currentTarget}));
            }

            RayCastLogic();
        }

       

        public void SetCurrentTarget(CellInfo newTargetCell)
        {
            this.currentTarget = newTargetCell;
        }

        public void RayCastLogic()
        {
            Vector2[] directions = { Vector2.up, Vector2.down, Vector2.right, Vector2.left };

            foreach (var dir in directions)
            {
                RaycastHit2D hit = Physics2D.Raycast(transform.position, dir, rayDistance);

                Debug.DrawRay(transform.position, dir * rayDistance, Color.white);
            }
        }
    }
}

