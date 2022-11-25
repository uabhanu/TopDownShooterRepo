using UnityEngine;

public class Aim : MonoBehaviour
{
    #region Variables

    [SerializeField] private GunDataSo gunDataSo;

    #endregion

    #region Functions
    
    public void AimGun(Vector2 worldPositionToAimAt)
    {
        Vector3 aimDirection = (Vector3)worldPositionToAimAt - transform.position;
        float desiredAngle = (Mathf.Atan2(aimDirection.y , aimDirection.x) * Mathf.Rad2Deg) - gunDataSo.GunRotationAngleOffset;
        transform.rotation = Quaternion.RotateTowards(transform.rotation , Quaternion.Euler(0f , 0f , desiredAngle) , gunDataSo.RotationSpeed * Time.deltaTime);
        
        //This gave an interesting effect that can be used as a power up along with reducing the reload time to 0.5f or less
        //transform.localRotation = Quaternion.RotateTowards(transform.rotation , Quaternion.Euler(0f , 0f , desiredAngle) , gunDataSo.RotationSpeed * Time.deltaTime);
    }

    #endregion
}
