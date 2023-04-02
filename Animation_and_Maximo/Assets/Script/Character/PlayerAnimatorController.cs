using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimatorController : MonoBehaviour
{
   [SerializeField] private Animator _animator;
   [SerializeField] private InputManager _inputManager;

  protected InputManager Manager { get { return _inputManager; }}


   #region  MOVE INPUT

   private float _inputY;
   private float _inputX;

   #endregion
   
   private void Update()
   {
     UpdateAnimations();
     UpdateValues();
   }
   private void UpdateValues()
   {
      _inputX = Manager.VectorAnimationSpeedX;
      _inputY = Manager.VectorAnimationSpeedY;
   }
  
   private void UpdateAnimations()
   {
     _animator.SetFloat("InputX",   _inputX);
     _animator.SetFloat("InputY", _inputY);
   }
}
