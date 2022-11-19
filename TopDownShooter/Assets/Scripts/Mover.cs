using UnityEngine;

public class Mover : MonoBehaviour
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

    public void Move(Vector2 movementDirectionBasedOnWASDKeys)
    {
        CalculateCurrentDirection(movementDirectionBasedOnWASDKeys);

        _playerBody2D.velocity = transform.up * (_currentMovementDirection * movementDataSo.MovementSpeed * Time.deltaTime);
        _playerBody2D.MoveRotation(transform.rotation * Quaternion.Euler(0f , 0f , -movementDirectionBasedOnWASDKeys.x * movementDataSo.RotationSpeed * Time.deltaTime));
    }

    #endregion
}
