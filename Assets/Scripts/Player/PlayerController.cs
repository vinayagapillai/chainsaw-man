using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("INPUT")] 
    private PlayerInputActions _playerInput;
    private Vector2 _moveInput = Vector2.zero;
    private Vector2 _lookInput = Vector2.zero;
    

    private void OnEnable()
    {
        _playerInput.HumanLand.Enable();

        _playerInput.HumanLand.Movement.performed += SetMoveValue;
        _playerInput.HumanLand.Movement.performed += SetMoveValue;
        
        _playerInput.HumanLand.Look.performed += SetLookValue;
        _playerInput.HumanLand.Look.canceled += SetLookValue;
    }

    private void OnDisable()
    {
        _playerInput.HumanLand.Movement.performed -= SetMoveValue;
        _playerInput.HumanLand.Movement.performed -= SetMoveValue;
        
        _playerInput.HumanLand.Look.performed -= SetLookValue;
        _playerInput.HumanLand.Look.canceled -= SetLookValue;
        
        _playerInput.HumanLand.Disable();
    }

    private void SetMoveValue(InputAction.CallbackContext obj)
    {
        _moveInput = obj.ReadValue<Vector2>();
    }
    private void SetLookValue(InputAction.CallbackContext obj)
    {
        _lookInput = obj.ReadValue<Vector2>();
    }
    
    


}
