using UnityEngine;

namespace AI
{
    public abstract class EnemyAIBehaviour : MonoBehaviour
    {
        public abstract void PerformAction(AIDetector aiDetector , CharacterController characterController);
    }
}
