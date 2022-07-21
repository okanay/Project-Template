using System;
using UnityEngine;
public class Player : CostumBehaviour
{
    private void Awake()
    {
        #region Event Connect

        EventManager.OnGameStart += OnGameStart;
        EventManager.OnGameEnd += OnGameEnd;
        EventManager.OnLevelCompleted += OnLevelCompleted;
        EventManager.OnLevelFail += OnLevelFail;
        EventManager.OnLevelStart += OnLevelStart;

        #endregion
    }
    private void OnGameStart()
    {
    // PlayerManager.MovementActivate.Invoke();                              // HyperCasual - Transform Movement
     PlayerManager.MovementActivate.Invoke(true, false);   // Casual - Rigidbody Movement.
    // PlayerManager.MovementActivate.Invoke(false, true);                   //  Casual - Transform Movement.
    }
    private void OnGameEnd()
    {
    }

    private void OnLevelStart()
    {
    }

    private void OnLevelCompleted()
    {
    }

    private void OnLevelFail()
    {
    }

}