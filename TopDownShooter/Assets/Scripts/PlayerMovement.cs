using Events;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    #region Variables

    private Rigidbody2D _playerBody2D;

    #endregion

    #region Functions

    private void Awake()
    {
        _playerBody2D = GetComponent<Rigidbody2D>();
        SubscribeToEvents();
    }

    private void OnDestroy()
    {
        UnsubscribeFromEvents();   
    }

    private void OnMovementKeysPressed(Vector2 movementVector)
    {
        _playerBody2D.velocity = new Vector2(movementVector.x , movementVector.y);
    }

    private void SubscribeToEvents()
    {
        InputEventsManager.SubscribeToEvent(InputEvent.MovementKeysPressed , OnMovementKeysPressed);
    }

    private void UnsubscribeFromEvents()
    {
        InputEventsManager.UnsubscribeFromEvent(InputEvent.MovementKeysPressed , OnMovementKeysPressed);
    }

    #endregion
}
