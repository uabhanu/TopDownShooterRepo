using UnityEngine;

[CreateAssetMenu (fileName = "NewGunData" , menuName = "DataSo/NewGunDataSo")]
public class GunDataSo : ScriptableObject
{
    public float GunRotationAngleOffset; //Setting this to 90 for some reason is giving the correct outcome.
    public float ReloadTime;
    public float RotationSpeed;
    public GameObject BulletPrefab;
}
