using UnityEngine;

namespace AI
{
    public class EnemyAIBehaviourDefault : MonoBehaviour
    {
        [SerializeField] private AIDetector aiDetector;
        [SerializeField] private CharacterController characterController;
        [SerializeField] private EnemyAIBehaviour enemyPatrolBehaviour;
        [SerializeField] private EnemyAIBehaviour enemyShootBehaviour;

        private void Update()
        {
            if(aiDetector.IsPlayerInSight())
            {
                enemyShootBehaviour.PerformAction(aiDetector , characterController);
            }
            else
            {
                enemyPatrolBehaviour.PerformAction(aiDetector , characterController);
            }
        }
    }
}
