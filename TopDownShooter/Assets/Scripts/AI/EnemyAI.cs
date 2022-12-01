using UnityEngine;

namespace AI
{
    public abstract class EnemyAI : MonoBehaviour
    {
        public abstract void PerformAction(AIDetector aiDetector , CharacterController characterController);
    }
}
