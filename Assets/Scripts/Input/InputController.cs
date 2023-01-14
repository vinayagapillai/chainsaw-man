using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputController : MonoBehaviour
{
    
    [Header("INPUT")] 
    private PlayerInputActions _playerInput;
    public Vector3 MovementInputRaw { get; private set; }
    public Vector3 MouseInputRaw { get; private set; }

    public bool InvertMouseY = true;
    
    private void OnEnable()
    {
        _playerInput = new PlayerInputActions();
        _playerInput.HumanLand.Enable();

        _playerInput.HumanLand.Movement.performed += SetMoveValue;
        _playerInput.HumanLand.Movement.canceled += SetMoveValue;
        
        _playerInput.HumanLand.Look.performed += SetLookValue;
        _playerInput.HumanLand.Look.canceled += SetLookValue;
    }

    private void OnDisable()
    {
        _playerInput.HumanLand.Movement.performed -= SetMoveValue;
        _playerInput.HumanLand.Movement.canceled -= SetMoveValue;
        
        _playerInput.HumanLand.Look.performed -= SetLookValue;
        _playerInput.HumanLand.Look.canceled -= SetLookValue;
        
        _playerInput.HumanLand.Disable();
    }
    
    
    #region INPUT SETTERS
    
    private void SetMoveValue(InputAction.CallbackContext obj)
    {
        MovementInputRaw = obj.ReadValue<Vector2>();
    }
    private void SetLookValue(InputAction.CallbackContext obj)
    {
        MouseInputRaw = obj.ReadValue<Vector2>();
    }
    #endregion
}
