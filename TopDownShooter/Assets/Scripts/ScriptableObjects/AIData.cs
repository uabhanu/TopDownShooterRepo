using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu (fileName = "NewAIData" , menuName = "DataSo/NewAIDataSo")]
    public class AIData : ScriptableObject
    {
        public float DetectorRadius;
    }
}
