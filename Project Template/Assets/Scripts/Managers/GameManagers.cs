using System;
using UnityEngine;
// ReSharper disable All
public class GameManagers : MonoBehaviour
    {
        // Check 'CostumeBehaviour' class.
        public EventManager EventManager;
        public PlayerManager PlayerManager;
        public LevelManager LevelManager;
        public CameraManager CameraManager;
        public CanvasManager CanvasManager;
        public static GameManagers Instance; 
        private void Awake()
        {
            Instance = this;
            
            Application.targetFrameRate = Screen.currentResolution.refreshRate;
            #if UNITY_EDITOR
            Application.targetFrameRate = Int32.MaxValue;
            #endif
        }
    }
