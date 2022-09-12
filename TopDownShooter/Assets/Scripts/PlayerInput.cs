using Events;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    #region Variables
    
    private PlayerInputControls _playerInputControls;

    #endregion

    #region Functions

    private void Awake()
    {
        _playerInputControls = new PlayerInputControls();

        
        _playerInputControls.Land.Aim.performed += AimInput;
        _playerInputControls.Land.Move.performed += MoveInput;
        _playerInputControls.Land.Shoot.performed += ShootInput;
    }

    private void OnEnable()
    {
        _playerInputControls.Enable();
    }

    private void OnDisable()
    {
        _playerInputControls.Disable();
    }

    private void AimInput(InputAction.CallbackContext callbackContext)
    {
        Vector2 aimVector = callbackContext.ReadValue<Vector2>();
        InputEventsManager.Invoke(InputEvent.MouseMoved , aimVector);
    }

    private void MoveInput(InputAction.CallbackContext callbackContext)
    {
        Vector2 movementVector = callbackContext.ReadValue<Vector2>();
        InputEventsManager.Invoke(InputEvent.MovementKeysPressed , movementVector);
    }

    private void ShootInput(InputAction.CallbackContext callbackContext)
    {
        InputEventsManager.Invoke(InputEvent.MouseLeftClicked);
    }

    #endregion
}
