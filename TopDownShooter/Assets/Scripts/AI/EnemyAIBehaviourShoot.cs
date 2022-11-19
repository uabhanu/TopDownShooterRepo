using UnityEngine;

namespace AI
{
    public class EnemyAIBehaviourShoot : EnemyAIBehaviour
    {
        public override void PerformAction(AIDetector aiDetector , CharacterController characterController)
        {
            Debug.Log("Enemy Shooting");
        }
    }
}
