using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimatorController : MonoBehaviour
{
   [SerializeField] private Animator _animator;
   [SerializeField] private InputManager _inputManager;


   #region  MOVE INPUT

   private float _inputY;

   #endregion
   
   private void Update()
   {
     UpdateAnimations();
     UpdateValues();
   }
   private void UpdateValues()
   {
     _inputY = _inputManager.GameControls.Player.Walk.ReadValue<Vector2>().y;
   }

   private void UpdateAnimations()
   {
     _animator.SetFloat("InputY", _inputY);
   }
}
