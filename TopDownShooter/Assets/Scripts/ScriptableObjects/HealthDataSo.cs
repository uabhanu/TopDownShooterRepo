using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu (fileName = "NewCharacterStatsData" , menuName = "DataSo/NewCharacterStatsData")]
    public class HealthDataSo : ScriptableObject
    {
        public int MaxHealth = 100;
    }
}
