using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FemaleNofaceController : MonoBehaviour
{
     private Animator _anim;

   #region TIMER
   
   [SerializeField] private float _currentTime;
   [SerializeField] private float _endTime;

    #endregion

   private void Awake()
   {
       _anim = GetComponent<Animator>();
   }

   private void Update()
   {
        _currentTime += Time.deltaTime;

        if(_currentTime < _endTime)
        {
           _anim.SetBool("nff_walk", false);
        
        }
        else if(_currentTime >= _endTime)
        {
            _anim.SetBool("nff_walk", true);
            Invoke("Walk", 5f);
        }
    }

    private void Walk()
    {
        _currentTime = 0;
    }
}
