using Events;
using UnityEngine;

public class Gun : MonoBehaviour
{
    #region Variables

    [SerializeField] private GunDataSo gunDataSo;
    [SerializeField] private Transform barrelTransform;

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

    private void Shoot()
    {
        Instantiate(gunDataSo.BulletPrefab , barrelTransform.position , Quaternion.identity);
    }

    private void OnMouseLeftClicked()
    {
        Shoot();
    }

    private void SubscribeToEvents()
    {
        InputEventsManager.SubscribeToEvent(InputEvent.MouseLeftClicked , OnMouseLeftClicked);
    }

    private void UnsubscribeFromEvents()
    {
        InputEventsManager.UnsubscribeFromEvent(InputEvent.MouseLeftClicked , OnMouseLeftClicked);
    }

    #endregion
}
