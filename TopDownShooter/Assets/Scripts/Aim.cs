using UnityEngine;

public class Aim : MonoBehaviour
{
    #region Variables

    [SerializeField] private GunDataSo gunDataSo;

    #endregion

    #region Functions
    
    public void AimGun(Vector2 aimVector)
    {
        var aimDirection = (Vector3)aimVector - transform.position;
        var desiredAngle = Mathf.Atan2(aimDirection.y , aimDirection.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.RotateTowards(transform.rotation , Quaternion.Euler(0f , 0f , desiredAngle) , gunDataSo.RotationSpeed * Time.deltaTime);
    }

    #endregion
}
