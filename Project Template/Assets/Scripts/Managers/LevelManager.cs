using System;
using UnityEngine;

    public class LevelManager : CostumBehaviour
    {
        private void Awake()
        {
            #region  Event Connect
            
            EventManager.OnLevelCompleted += OnLevelCompleted;
            EventManager.OnLevelFail += OnLevelFail;
            EventManager.OnLevelStart += OnLevelStart;

            #endregion
        }

        #region Events
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

