using UnityEngine;

namespace AI
{
    public class EnemyAIBehaviourDefault : MonoBehaviour
    {
        #region Variables
        
        [SerializeField] private AIDetector aiDetector;
        [SerializeField] private CharacterController characterController;
        [SerializeField] private EnemyAI enemyAIPatrol;
        [SerializeField] private EnemyAI enemyAIShoot;
        

        #endregion

        #region Functions

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
        
        #endregion
    }
}
