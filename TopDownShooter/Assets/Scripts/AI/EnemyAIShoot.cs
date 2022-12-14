namespace AI
{
    public class EnemyAIShoot : EnemyAI
    {
        #region Functions
        
        public override void PerformAction(AIDetector aiDetector , CharacterController characterController)
        {
            if(aiDetector.IsPlayerInSight())
            {
                characterController.Aim.AimGun(aiDetector.PlayerCollider2D.transform.position);
                characterController.Gun.Shoot();
            }
        }
        
        #endregion
    }
}
