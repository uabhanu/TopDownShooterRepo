using Events;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    #region Variables

    private ShootHelper _shootHelper;

    #endregion

    #region Functions

    private void Awake()
    {
        _shootHelper = GetComponentInParent<ShootHelper>();
        SubscribeToEvents();
    }

    private void OnDestroy()
    {
        UnsubscribeFromEvents();   
    }

    private void OnMouseLeftClicked()
    {
        _shootHelper.ShootObject();
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
