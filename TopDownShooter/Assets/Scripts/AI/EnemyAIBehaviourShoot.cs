using ScriptableObjects;
using UnityEngine;

namespace AI
{
    public class EnemyAIBehaviourShoot : EnemyAIBehaviour
    {
        #region Variables
        
        [SerializeField] private AIDataSo aiDataSo;

        #endregion
        
        #region Functions
        
        public override void PerformAction(AIDetector aiDetector , CharacterController characterController)
        {
            Debug.Log("Enemy Shooting Behaviour");
        }
        
        #endregion
    }
}
