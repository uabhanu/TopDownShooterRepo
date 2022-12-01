using ScriptableObjects;
using UnityEngine;

namespace AI
{
    public class EnemyAIPatrolStationary : EnemyAI
    {
        #region Variables
        
        private float _timeLastReset;
        private Vector2 _randomPosition;
        
        [SerializeField] private AIDataSo aiDataSo;
        
        #endregion

        #region Functions
        
        private void Awake()
        {
            _timeLastReset = Time.time;
            _randomPosition = Random.insideUnitCircle;
        }

        public override void PerformAction(AIDetector aiDetector , CharacterController characterController)
        {
            if(Time.time - _timeLastReset >= aiDataSo.PatrolDelay)
            {
                _randomPosition = (Vector2)transform.position + Random.insideUnitCircle * aiDataSo.DetectorRadius;
                _timeLastReset = Time.time;
            }
            
            characterController.Aim.AimGun(_randomPosition);
        }
        
        #endregion
    }
}
