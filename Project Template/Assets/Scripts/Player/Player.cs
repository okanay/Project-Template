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

        private void Start()
        {
            Debug.Log("GitHub Test.");
        }

        #region Events

        private void OnGameStart()
        {
            Debug.Log("Player");
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