using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField] private GameControls _gameControls;


    private void Awake()
    {
        #region INPUT ASSIGNMENT

        _gameControls = new GameControls();
        
        #endregion

    }

         #region INPUT ENABLE/DISABLE

    private void OnEnable() 
    {
        _gameControls.Enable();
    }
    
    private void OnDisable() 
    {
        _gameControls.Disable();
    }

    #endregion

    public GameControls GameControls
    {
        get {return _gameControls; }
    }

}
