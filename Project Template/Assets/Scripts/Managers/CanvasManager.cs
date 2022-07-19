using System;
using UnityEngine;

public class CanvasManager : CostumBehaviour
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

        #region Events

        private void OnGameStart()
        {
        
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

        #endregion
    }

