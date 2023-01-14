using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(InputController))]
public class PlayerController : MonoBehaviour
{
    [Header("INPUT")] 
    private InputController _input;
    
    [Header("PLAYER REFERENCES")] 
    private Rigidbody _rb;
    [SerializeField] private Transform _playerFollowPoint; 

    [Header("MOVEMENT VALUES")] 
    [SerializeField] private float _movementMultiplier;
    [SerializeField] private float _playerRoataionSpeed = 1;
    
    private Vector3 _playerLookInput = Vector2.zero;
    private Vector3 _previousPlayerLookInput = Vector2.zero;
    private float _playerLookLerpTime = 0.35f;
    private float _cameraPitch;
    [SerializeField] private float _cameraPitchSpeed;
    
    
    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _input = GetComponent<InputController>();
        
    }
    
    private void FixedUpdate()
    {
        _playerLookInput = UpdatePlayerLookInput();
        _rb.AddRelativeForce(GetRelativeVelocity(), ForceMode.Force);
        _rb.rotation = Quaternion.Euler(0,_rb.rotation.eulerAngles.y  + (_playerLookInput.x * _playerRoataionSpeed),0);
        UpdateCameraRotaion();
    }

    private Vector3 GetRelativeVelocity()
    {
        Vector3 relativeVelocity = new Vector3( _input.MovementInputRaw.x * _rb.mass * _movementMultiplier, 0, _input.MovementInputRaw.y * _rb.mass * _movementMultiplier);
        return relativeVelocity;
    }

    private Vector3 UpdatePlayerLookInput()
    {
        _previousPlayerLookInput = _playerLookInput;
        _playerLookInput = new Vector3(_input.MouseInputRaw.x, (_input.InvertMouseY ? -_input.MouseInputRaw.y : _input.MouseInputRaw.y), 0);
        return Vector3.Lerp(_previousPlayerLookInput, _playerLookInput * Time.deltaTime, _playerLookLerpTime);
    }
    private void UpdateCameraRotaion()
    {
        _cameraPitch += _playerLookInput.y * _cameraPitchSpeed;
        _cameraPitch = Mathf.Clamp(_cameraPitch, -89.9f, 89.9f);

        _playerFollowPoint.rotation = Quaternion.Euler(_cameraPitch, _playerFollowPoint.rotation.eulerAngles.y, _playerFollowPoint.rotation.eulerAngles.z);

    }


    
    
    


}
