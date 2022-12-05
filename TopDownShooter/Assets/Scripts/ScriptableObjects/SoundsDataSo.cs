using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu (fileName = "NewSoundsData" , menuName = "DataSo/NewSoundsDataSo")]
    public class SoundsDataSo : ScriptableObject
    {
        public AudioClip ShootClip;
    }
}
