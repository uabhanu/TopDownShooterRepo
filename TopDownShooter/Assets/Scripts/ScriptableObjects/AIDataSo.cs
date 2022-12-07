using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu (fileName = "NewAIData" , menuName = "DataSo/NewAIDataSo")]
    public class AIDataSo : ScriptableObject
    {
        public float DetectorRadius;
        public float PatrolDelay;
        public int DeathScoreValue;
    }
}
