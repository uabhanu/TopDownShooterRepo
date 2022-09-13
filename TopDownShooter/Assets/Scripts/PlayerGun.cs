using Events;
using UnityEngine;

public class PlayerGun : MonoBehaviour
{
    #region Variables

    [SerializeField] private Camera mainCamera;
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
        transform.rotation = Quaternion.RotateTowards(transform.rotation , Quaternion.Euler(0f , 0f , desiredAngle * gunDataSo.RotationSpeed * Time.deltaTime) , gunDataSo.MaxDegreesDelta);
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
