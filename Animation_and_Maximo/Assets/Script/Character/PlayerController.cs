using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerController : MonoBehaviour
{
      [Header("Components")]
    [Space(15)]
    [SerializeField] private InputManager _inputHandler;
    private CharacterController _characterController;
    private Animator _animator;

    [Header("Player Parameters")]
    [Space(15)]
    [SerializeField] private float _walkSpeed;
    [SerializeField] private float _runSpeed;
    [Range(1,20),SerializeField]private float _rotationFactorPerFrame;
    private Vector3 _currentMove;
    private Vector2 _currentMoveInput;
    private Vector3 _currentRunMove;
    private Vector3 _appliedMove;
    private bool _isMovePressed;
    private bool _isRunPressed;

    protected InputManager Manager { get { return _inputHandler; }}

    private void Awake() 
    {
        _animator = GetComponent<Animator>();
        _characterController = GetComponent<CharacterController>();
        //Cursor.lockState = CursorLockMode.Locked;
        //Cursor.visible = false;

    }

    private void Start() 
    {
         #region Input Settup


        Manager.GameControls.Player.Walk.performed += OnMovementInput;
        Manager.GameControls.Player.Walk.canceled += OnMovementInput;

        Manager.GameControls.Player.Run.started += OnRunInput;
       Manager.GameControls.Player.Run.canceled += OnRunInput;  




        #endregion    
    }
    private void Update() 
    {
       HandleGravity();
       HandleRotation();
       WalkAndRun();

       _appliedMove.z = _isRunPressed ? _currentMoveInput.y * _runSpeed : _currentMoveInput.y;
       _appliedMove.x = _isRunPressed ? _currentMoveInput.x * _runSpeed : _currentMoveInput.x;

       if(!_isRunPressed && _isMovePressed)
       {
            _appliedMove.x = _currentMoveInput.x * _walkSpeed;
            _appliedMove.z = _currentMoveInput.y * _walkSpeed; 
       }

       _characterController.Move(_appliedMove * Time.deltaTime);


        Vector3 animationInput;

        animationInput.x = _appliedMove.x;
        animationInput.z = _appliedMove.z;
        Manager.VectorAnimationSpeedX = animationInput.x;
        Manager.VectorAnimationSpeedY = animationInput.z;
    }

    private void HandleGravity()
    {
        if(_characterController.isGrounded)
        {
            float  groundedGravity = -.05f;
            _appliedMove.y = groundedGravity;
        }
        else 
        {
            float gravity = -9.8f;
            _appliedMove.y += gravity;
        }
    }

    private void HandleRotation()
    {
        Vector3 positionToLookAt;

        positionToLookAt.x = _currentMove.x;
        positionToLookAt.y = 0.0f;
        positionToLookAt.z = _currentMove.z;

        Quaternion currentRotation = transform.rotation;

       if(_isMovePressed)
       {
         Quaternion targetRotation = Quaternion.LookRotation(positionToLookAt);
         transform.rotation = Quaternion.Slerp(currentRotation, targetRotation, _rotationFactorPerFrame * Time.deltaTime);  
       
       }
    }
  
    #region Input Methods

    private void OnMovementInput (InputAction.CallbackContext ctx)
    {
        _currentMoveInput = ctx.ReadValue<Vector2>();

        _isMovePressed = _currentMoveInput.x != 0 || _currentMoveInput.y != 0;
    }

    private void OnRunInput(InputAction.CallbackContext ctx)
    {
        _isRunPressed = ctx.ReadValueAsButton();
    } 

     #endregion
    private void WalkAndRun()
    {
        _currentMove = new Vector3(_currentMoveInput.x, 0f, _currentMoveInput.y);
        _currentMove.y = 0f;
        _currentRunMove = new Vector3(_currentMoveInput.x, 0f, _currentMoveInput.y);
        _currentRunMove.y = 0f;

    }
}
