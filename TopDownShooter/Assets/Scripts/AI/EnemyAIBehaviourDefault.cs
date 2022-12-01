using UnityEngine;

namespace AI
{
    public class EnemyAIBehaviourDefault : MonoBehaviour
    {
        [SerializeField] private AIDetector aiDetector;
        [SerializeField] private CharacterController characterController;
        [SerializeField] private EnemyAI enemyAIPatrol;
        [SerializeField] private EnemyAI enemyAIShoot;

        private void Update()
        {
            if(aiDetector.IsPlayerInSight())
            {
                enemyAIShoot.PerformAction(aiDetector , characterController);
            }
            else
            {
                enemyAIPatrol.PerformAction(aiDetector , characterController);
            }
        }
    }
}
