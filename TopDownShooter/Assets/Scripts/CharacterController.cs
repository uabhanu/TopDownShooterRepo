using Events;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    #region Variables
    
    [SerializeField] private Aim aim;
    [SerializeField] private Gun gun;
    [SerializeField] private Mover mover;
    
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
    
    private void OnMouseLeftClicked()
    {
        gun.Shoot();
    }

    private void OnMouseMoved(Vector2 aimVector)
    {
        aim.AimGun(aimVector);
    }

    private void OnMovementKeysPressed(Vector2 moveVector)
    {
        mover.Move(moveVector);
    }

    private void SubscribeToEvents()
    {
        InputEventsManager.SubscribeToEvent(InputEvent.MouseLeftClicked , OnMouseLeftClicked);
        InputEventsManager.SubscribeToEvent(InputEvent.MouseMoved , OnMouseMoved);
        InputEventsManager.SubscribeToEvent(InputEvent.MovementKeysPressed , OnMovementKeysPressed);
    }

    private void UnsubscribeFromEvents()
    {
        InputEventsManager.UnsubscribeFromEvent(InputEvent.MouseLeftClicked , OnMouseLeftClicked);
        InputEventsManager.UnsubscribeFromEvent(InputEvent.MouseMoved , OnMouseMoved);
        InputEventsManager.UnsubscribeFromEvent(InputEvent.MovementKeysPressed , OnMovementKeysPressed);
    }

    #endregion
}
