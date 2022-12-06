using UnityEngine;

[CreateAssetMenu (fileName = "NewBulletData" , menuName = "DataSo/NewBulletDataSo")]
public class BulletDataSo : ScriptableObject
{
    public float DistanceTravelledCheckTimer;
    public float MaxDistanceTravelled;
    public float TravelSpeed;
    public int Damage;
}
