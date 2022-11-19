using Events;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputManager : MonoBehaviour
{
    #region Variables
    
    private PlayerInputControls _playerInputControls;
    private Vector2 _aimVector;
    private Vector2 _movementVector;
    
    [SerializeField] private Camera mainCamera;

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

    private Vector2 GetMousePosition()
    {
        Vector3 mousePosition = _aimVector;
        mousePosition.z = mainCamera.nearClipPlane;
        Vector2 mouseWorldPoition = mainCamera.ScreenToWorldPoint(mousePosition);
        return mouseWorldPoition.normalized; //Adding normalized improved the movement but the effect is not quite what I wanted but at this time, good to go
    }

    private void GetAim()
    {
        InputEventsManager.Invoke(InputEvent.MouseMoved , GetMousePosition());
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
