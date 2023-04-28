using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimatorController : MonoBehaviour
{
   [SerializeField] private Animator _animator;
   [SerializeField] private InputManager _inputManager;
   private PlayerController _playerController;

  protected InputManager Manager { get { return _inputManager; }}


   #region  MOVE INPUT

   private float _inputY;
   private float _inputX;
   private bool _isJumpTrigger;

   #endregion

   private void Awake() 
   {
      _playerController = GetComponent<PlayerController>(); 
   }
   
   private void Update()
   {
      UpdateAnimations();
      UpdateValues();
      JumpAndFallAnimations();
   }
   private void UpdateValues()
   {
      _inputX = Manager.VectorAnimationSpeedX;
      _inputY = Manager.VectorAnimationSpeedY;
      _isJumpTrigger = _playerController.JumpPressed;
   }
  
   private void UpdateAnimations()
   {
     _animator.SetFloat("InputX",   _inputX);
     _animator.SetFloat("InputY", _inputY);
   }

   private void JumpAndFallAnimations()
   {
     if(_isJumpTrigger  && _playerController.CharacterControl.isGrounded)
     {
        _animator.SetBool("Jump", true);
     }
     else if(!_playerController.CharacterControl.isGrounded && !_isJumpTrigger)
     {
        _animator.SetBool("Falling", true);
     }

     if(_playerController.CharacterControl.isGrounded && !_isJumpTrigger)
     {
        _animator.SetBool("Jump", false);
        _animator.SetBool("Falling", false);
     }
  
   }
}
