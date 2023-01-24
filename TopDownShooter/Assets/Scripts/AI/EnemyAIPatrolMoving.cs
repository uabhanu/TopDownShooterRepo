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
        [SerializeField] private Transform[] moveLocationTransforms;

        #endregion

        #region Functions

        private void CalculateDestination()
        {
            for(int i = 0; i < moveLocationTransforms.Length; i++)
            {
                if(transform.position == moveLocationTransforms[i].position)
                {
                    if(i >= moveLocationTransforms.Length - 1)
                    {
                        _currentDestinationTransform = moveLocationTransforms[moveLocationTransforms.Length - 1];    
                    }
                    
                    else if(i < moveLocationTransforms.Length - 1)
                    {
                        _currentDestinationTransform = moveLocationTransforms[i + 1];
                    }
                }

                if(transform.position == moveLocationTransforms[moveLocationTransforms.Length - 1].position)
                {
                    for(int j = moveLocationTransforms.Length - 1; j > 0; j--)
                    {
                        if(j < 0)
                        {
                            _currentDestinationTransform = moveLocationTransforms[0];
                        }
                        else
                        {
                            _currentDestinationTransform = moveLocationTransforms[j - 1];
                        }
                    }
                }
            }
        }

        private void Patrol()
        {
            transform.position = Vector2.MoveTowards(transform.position , _currentDestinationTransform.position , movementDataSo.MovementSpeed * Time.deltaTime);
        }

        // private void Patrol(AIDetector aiDetector , CharacterController characterController)
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
            //Patrol(aiDetector , characterController);
            Patrol();
            RotateTowardsDestination();
        }

        #endregion
    }
}
