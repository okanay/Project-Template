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
        PlayerManager.MovementActivate.Invoke();
        PlayerManager.AnimationChange.Invoke(Run, 0.25f);
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