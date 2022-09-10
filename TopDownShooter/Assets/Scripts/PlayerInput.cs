using Events;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    #region Variables
    
    private PlayerInputControls _playerInputControls;
    private Vector2 _movementVector;

    #endregion

    #region Functions

    private void Awake()
    {
        _playerInputControls = new PlayerInputControls();

        _playerInputControls.Land.Move.performed += MoveInput;
    }

    private void OnEnable()
    {
        _playerInputControls.Enable();
    }

    private void OnDisable()
    {
        _playerInputControls.Disable();
    }

    private void MoveInput(InputAction.CallbackContext callbackContext)
    {
        _movementVector = callbackContext.ReadValue<Vector2>();
        InputEventsManager.Invoke(InputEvent.MovementKeysPressed , _movementVector);
    }

    #endregion
}
