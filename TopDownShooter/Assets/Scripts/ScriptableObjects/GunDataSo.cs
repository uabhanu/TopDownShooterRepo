using UnityEngine;

[CreateAssetMenu (fileName = "NewGunData" , menuName = "DataSo/NewGunDataSo")]
public class GunDataSo : ScriptableObject
{
    public float RotationSpeed;
    public GameObject BulletPrefab;
}
