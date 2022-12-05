using Events;
using ScriptableObjects;
using UnityEngine;

public class Gun : MonoBehaviour
{
    #region Variables

    private bool _canShoot = true;
    private float _time;

    [SerializeField] private bool belongsToPlayer;
    [SerializeField] private GunDataSo gunDataSo;
    [SerializeField] private SoundsDataSo soundsDataSo;
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
            GameEventsManager.Invoke(GameEvent.Shoot , soundsDataSo.ShootClip);
            Instantiate(gunDataSo.BulletPrefab , barrelTransform.position , barrelTransform.rotation);
            _canShoot = false;
            _time = gunDataSo.ReloadTime;

            if(belongsToPlayer)
            {
                GameEventsManager.Invoke(GameEvent.PlayerGunReloading);
            }
        }
    }
    
    #endregion
}
