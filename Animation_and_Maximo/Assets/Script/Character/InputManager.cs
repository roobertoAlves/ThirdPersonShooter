using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField] private GameControls _gameControls;
    private Vector3 _vectorAnimation;


    public float VectorAnimationSpeedY {get { return _vectorAnimation.y; } set { _vectorAnimation.y = value; }}
    public float VectorAnimationSpeedX {get { return _vectorAnimation.x; } set { _vectorAnimation.x = value; }}
    private void Awake()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked; 
        
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
