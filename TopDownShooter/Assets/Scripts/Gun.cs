using Events;
using UnityEngine;

public class Gun : MonoBehaviour
{
    #region Variables

    private bool _canShoot = true;
    private float _time;

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

    private void Update()
    {
        if(!_canShoot)
        {
            _time -= Time.deltaTime;

            if(_time <= 0)
            {
                _canShoot = true;
            }
        }
    }

    private void Shoot()
    {
        Instantiate(gunDataSo.BulletPrefab , barrelTransform.position , barrelTransform.rotation);
        GameEventsManager.Invoke(GameEvent.Reloading);
    }

    private void OnMouseLeftClicked()
    {
        if(_canShoot)
        {
            Shoot();
            _canShoot = false;
            _time = gunDataSo.ReloadTime;
        }
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
