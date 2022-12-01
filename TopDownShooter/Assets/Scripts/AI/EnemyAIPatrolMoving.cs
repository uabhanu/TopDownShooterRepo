using UnityEngine;

namespace AI
{
    public class EnemyAIPatrolMoving : EnemyAI
    {
        #region Variables

        private Transform _currentDestinationTransform;

        [SerializeField] private MovementDataSo movementDataSo;
        [SerializeField] private Transform pointATransform;
        [SerializeField] private Transform pointBTransform;
        
        #endregion

        #region Functions

        private void CalculateDestination(CharacterController characterController)
        {
            if(characterController.transform.position == pointATransform.position)
            {
                _currentDestinationTransform = pointBTransform;
            }

            if(characterController.transform.position == pointBTransform.position)
            {
                _currentDestinationTransform = pointATransform;
            }
        }

        private void Patrol(CharacterController characterController)
        {
            characterController.transform.position = Vector2.MoveTowards(characterController.transform.position , _currentDestinationTransform.position , movementDataSo.MovementSpeed * Time.deltaTime);
        }

        public override void PerformAction(AIDetector aiDetector , CharacterController characterController)
        {
            CalculateDestination(characterController);
            Patrol(characterController);
        }
        
        #endregion
    }
}
