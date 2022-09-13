using Events;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    #region Variables
    
    private PlayerInputControls _playerInputControls;
    private Vector2 _aimVector;
    private Vector2 _movementVector;

    #endregion

    #region Functions

    private void Awake()
    {
        _playerInputControls = new PlayerInputControls();

        
        _playerInputControls.Land.Aim.performed += context => _aimVector = context.ReadValue<Vector2>();
        _playerInputControls.Land.Aim.canceled += context => _aimVector = Vector2.zero;

        _playerInputControls.Land.Move.performed += context => _movementVector = context.ReadValue<Vector2>();
        _playerInputControls.Land.Move.canceled += context => _movementVector = Vector2.zero;

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

    private void Update()
    {
        GetAim();
        GetMovement();
    }

    private void GetAim()
    {
        InputEventsManager.Invoke(InputEvent.MouseMoved , _aimVector);
    }
    
    private void GetMovement()
    {
        InputEventsManager.Invoke(InputEvent.MovementKeysPressed , _movementVector);
    }

    private void ShootInput(InputAction.CallbackContext noContextHere)
    {
        InputEventsManager.Invoke(InputEvent.MouseLeftClicked);
    }

    #endregion
}
