namespace AI
{
    public class EnemyAIBehaviourShoot : EnemyAIBehaviour
    {
        #region Functions
        
        public override void PerformAction(AIDetector aiDetector , CharacterController characterController)
        {
            if(aiDetector.Target() != null && aiDetector.IsTargetInSight())
            {
                characterController.Aim.AimGun(aiDetector.Target().transform.position);
                characterController.Gun.Shoot();
            }
        }
        
        #endregion
    }
}
