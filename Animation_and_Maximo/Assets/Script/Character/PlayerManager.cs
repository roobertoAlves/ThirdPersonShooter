using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
       #region Input
   [SerializeField] private InputManager _inputManager;
    #endregion
    
    #region Components

    [SerializeField] private GameObject _mainCamera;
    [SerializeField] private CharacterController _charControl;
    #endregion

    #region CAMERA 

    private Vector2 _viewInput;
    [SerializeField] private Transform _playerBody;
    [SerializeField, Range(1,20)] private float _mouseSense; 
    private float _camXRotation = 0f;

    #endregion

    #region Character Movement
    
    private Vector2 _moveInput;
    [SerializeField] private float _charSpeed;

    #endregion

    private Vector2 _walkDirection;

    private void Awake()
    {

        Cursor.visible = false;
        _charControl = GetComponent<CharacterController>();

        #region INPUT ASSIGNMENT
        _inputManager.GameControls.Player.Walk.performed += ctx =>_moveInput = ctx.ReadValue<Vector2>();
        _inputManager.GameControls.Player.Walk.canceled += ctx => _moveInput = Vector2.zero;

        _inputManager.GameControls.Player.View.performed += ctx => _viewInput = ctx.ReadValue<Vector2>();



        #endregion
    }
}
