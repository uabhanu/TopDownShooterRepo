using Events;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    #region Variables

    private ShootUtil _shootUtil;

    #endregion

    #region Functions

    private void Awake()
    {
        _shootUtil = GetComponentInParent<ShootUtil>();
        SubscribeToEvents();
    }

    private void OnDestroy()
    {
        UnsubscribeFromEvents();   
    }

    private void OnMouseLeftClicked()
    {
        _shootUtil.ShootObject();
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
