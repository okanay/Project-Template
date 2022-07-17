using UnityEngine;
public class Player : CostumBehaviour
{
    public delegate void MovementDelegate();
    public MovementDelegate GameStart;
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
            GameStart.Invoke();
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