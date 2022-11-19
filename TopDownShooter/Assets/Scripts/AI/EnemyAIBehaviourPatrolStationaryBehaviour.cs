using UnityEngine;

namespace AI
{
    public class EnemyAIBehaviourPatrolStationaryBehaviour : EnemyAIBehaviour
    {
        public override void PerformAction(AIDetector aiDetector , CharacterController characterController)
        {
            Debug.Log("Enemy Patrolling Stationary");
        }
    }
}
