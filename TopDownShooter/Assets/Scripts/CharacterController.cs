using Events;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    #region Variables

    [SerializeField] private bool isPlayer;

    public Aim Aim;
    public Gun Gun;
    public Mover Mover;
    
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

    #region Event Functions
    
    private void OnMouseLeftClicked()
    {
        if(!isPlayer) return;
        
        Gun.Shoot();
    }

    private void OnMouseMoved(Vector2 aimVector)
    {
        if(!isPlayer) return;
        
        Aim.AimGun(aimVector);
    }

    private void OnMovementKeysPressed(Vector2 moveVector)
    {
        if(!isPlayer) return;
        
        Mover.Move(moveVector);
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
