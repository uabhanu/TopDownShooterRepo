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

    public void Shoot()
    {
        if(_canShoot)
        {
            Instantiate(gunDataSo.BulletPrefab , barrelTransform.position , barrelTransform.rotation);
            GameEventsManager.Invoke(GameEvent.Reloading);
            _canShoot = false;
            _time = gunDataSo.ReloadTime;
        }
    }
    
    #endregion
}
