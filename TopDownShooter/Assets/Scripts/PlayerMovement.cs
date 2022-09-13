using Events;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    #region Variables

    private float _currentMovementDirection = 0f;
    private Rigidbody2D _playerBody2D;

    [SerializeField] private MovementDataSo movementDataSo;

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

    private void CalculateCurrentDirection(Vector2 movementVector)
    {
        if(movementVector.y > 0)
        {
            _currentMovementDirection = 1f;
        }
        
        else if(movementVector.y < 0)
        {
            _currentMovementDirection = -1f;
        }

        else
        {
            _currentMovementDirection = 0f;
        }
    }

    private void OnMovementKeysPressed(Vector2 movementVector)
    {
        CalculateCurrentDirection(movementVector);

        _playerBody2D.velocity = transform.up * _currentMovementDirection * movementDataSo.MovementSpeed * Time.deltaTime;
        _playerBody2D.MoveRotation(transform.rotation * Quaternion.Euler(0f , 0f , -movementVector.x * movementDataSo.RotationSpeed * Time.deltaTime));
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
