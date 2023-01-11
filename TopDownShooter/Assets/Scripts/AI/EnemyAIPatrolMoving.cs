using Unity.Mathematics;
using UnityEngine;

namespace AI
{
    public class EnemyAIPatrolMoving : EnemyAI
    {
        #region Variables

        private Transform _currentDestinationTransform;

        [SerializeField] private MovementDataSo movementDataSo;
        [SerializeField] private Transform gunTransform;
        //[SerializeField] private Transform[] moveLocationTransforms;
        [SerializeField] private Transform pointATransform;
        [SerializeField] private Transform pointBTransform;
        
        #endregion

        #region Functions

        private void CalculateDestination()
        {
            if(transform.position == pointATransform.position)
            {
                _currentDestinationTransform = pointBTransform;
            }
            
            else if(transform.position == pointBTransform.position)
            {
                _currentDestinationTransform = pointATransform;
            }

            // for(int i = 0; i < moveLocationTransforms.Length; i++)
            // {
            //     if(transform.position == moveLocationTransforms[i].position)
            //     {
            //         if(i >= moveLocationTransforms.Length)
            //         {
            //             _currentDestinationTransform = moveLocationTransforms[moveLocationTransforms.Length - 1];    
            //         }
            //         else
            //         {
            //             _currentDestinationTransform = moveLocationTransforms[i + 1];   
            //             //TODO Absolutely makes no sense why this is even executing so this is for later
            //         }
            //     }
            //
            //     if(_currentDestinationTransform == moveLocationTransforms[moveLocationTransforms.Length - 1])
            //     {
            //         Debug.Log("Final Destination Reached");
            //
            //         // for(int j = moveLocationTransforms.Length - 1; j > 0; j--)
            //         // {
            //         //     _currentDestinationTransform = moveLocationTransforms[j];
            //         // }
            //     }
            // }
        }

        private void Patrol()
        {
            transform.position = Vector2.MoveTowards(transform.position , _currentDestinationTransform.position , movementDataSo.MovementSpeed * Time.deltaTime);
        }

        // private void Patrol(CharacterController characterController)
        // {
        //     characterController.Mover.Move(_currentDestinationTransform.position - characterController.Mover.transform.position);
        // }

        private void RotateTowardsDestination()
        {
            Vector2 destDirection = _currentDestinationTransform.position - transform.position;
            float singleStep = movementDataSo.RotationSpeed * Time.deltaTime;
            Vector3 newDirection = Vector3.RotateTowards(transform.forward , destDirection , singleStep , 0f);
            transform.rotation = Quaternion.LookRotation(Vector3.forward , newDirection);
            gunTransform.rotation = quaternion.LookRotation(Vector3.forward , newDirection);
        }

        public override void PerformAction(AIDetector aiDetector , CharacterController characterController)
        {
            CalculateDestination();
            //Patrol(characterController);
            Patrol();
            RotateTowardsDestination();
        }

        #endregion
    }
}
