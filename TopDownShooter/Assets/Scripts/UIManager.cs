using Events;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    #region Variables
    
    private bool _playerGunReloading;
    private float _reloadTime;

    [SerializeField] private GunDataSo gunDataSo;
    [SerializeField] private Slider playerGunSlider;
    
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
        if(_playerGunReloading && _reloadTime < gunDataSo.ReloadTime)
        {
            _reloadTime += Time.deltaTime;
            playerGunSlider.value = _reloadTime / gunDataSo.ReloadTime;
        }

        if(playerGunSlider.value >= 1)
        {
            playerGunSlider.value = 0f;
            _playerGunReloading = false;
            _reloadTime = 0f;
        }
    }

    private void OnPlayerGunReloading()
    {
        _playerGunReloading = true;
    }
    
    private void SubscribeToEvents()
    {
        GameEventsManager.SubscribeToEvent(GameEvent.PlayerGunReloading , OnPlayerGunReloading);
    }

    private void UnsubscribeFromEvents()
    {
        GameEventsManager.UnsubscribeFromEvent(GameEvent.PlayerGunReloading , OnPlayerGunReloading);
    }
    
    #endregion
}
