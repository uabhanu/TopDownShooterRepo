using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu (fileName = "NewSoundsData" , menuName = "DataSo/NewSoundsDataSo")]
    public class SoundsDataSo : ScriptableObject
    {
        public AudioClip BulletExplosionClip;
        public AudioClip CharacterExplosionClip;
        public AudioClip ShootClip;
    }
}
