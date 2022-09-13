using Events;
using UnityEngine;

public class PlayerGun : MonoBehaviour
{
    #region Variables

    [SerializeField] private GunDataSo gunDataSo;

    #endregion

    #region Functions

    private void Awake()
    {
        SubscribeToEvents();
    }

    private void OnDestroy()
    {
        UnsubscribeFromEvents();   
    }

    private void OnMouseMoved(Vector2 aimVector)
    {
        var aimDirection = (Vector3)aimVector - transform.position;
        var desiredAngle = Mathf.Atan2(aimDirection.y , aimDirection.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.RotateTowards(transform.rotation , Quaternion.Euler(0f , 0f , desiredAngle) , gunDataSo.RotationSpeed * Time.deltaTime);

        var currentZRotationInDegrees = (transform.rotation.z * Mathf.Rad2Deg) * 2; // Z Rotation of the Inspector is Double this value
        Debug.Log("Current Z Rotation in Degrees : " + currentZRotationInDegrees);

        //The idea of this is to clamp the rotation between -45 & 45 degrees
        if(currentZRotationInDegrees < -45f)
        {
            Debug.Log("Set to -45 degrees");
        }

        if(currentZRotationInDegrees > 45f)
        {
            Debug.Log("Set to 45 degrees");
        }
    }

    private void SubscribeToEvents()
    {
        InputEventsManager.SubscribeToEvent(InputEvent.MouseMoved , OnMouseMoved);
    }

    private void UnsubscribeFromEvents()
    {
        InputEventsManager.UnsubscribeFromEvent(InputEvent.MouseMoved , OnMouseMoved);
    }

    #endregion
}
