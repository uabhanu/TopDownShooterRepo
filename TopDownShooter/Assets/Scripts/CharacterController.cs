using Events;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    #region Variables

    [SerializeField] private bool isPlayer;
    [SerializeField] private Aim aim;
    [SerializeField] private Gun gun;
    [SerializeField] private Mover mover;
    
    #endregion
    
    #region MonoBehaviour Functions

    private void Awake()
    {
        SubscribeToEvents();
    }

    private void OnDestroy()
    {
        UnsubscribeFromEvents();   
    }
    
    #endregion
    
    #region User Defined Functions

    public void HandleAim(Vector2 aimVector)
    {
        Debug.Log("Enemy Aiming");
    }

    public void HandleMovement(Vector2 movementVector)
    {
        Debug.Log("Enemy Moving");
    }

    public void HandleShoot()
    {
        Debug.Log("Enemy Shooting");
    }
    
    #endregion
    
    #region Event Functions
    
    private void OnMouseLeftClicked()
    {
        if(!isPlayer) return;
        
        gun.Shoot();
    }

    private void OnMouseMoved(Vector2 aimVector)
    {
        if(!isPlayer) return;
        
        aim.AimGun(aimVector);
    }

    private void OnMovementKeysPressed(Vector2 moveVector)
    {
        if(!isPlayer) return;
        
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
