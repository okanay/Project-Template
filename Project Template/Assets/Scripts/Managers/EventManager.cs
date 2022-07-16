using System;

public class EventManager : CostumBehaviour
{
    public event Action OnGameStart;
    public event Action OnGameEnd;
    public event Action OnLevelStart;
    public event Action OnLevelCompleted;
    public event Action OnLevelFail;

    public void GameStart() => OnGameStart?.Invoke();
    public void GameEnd() =>  OnGameEnd?.Invoke();
    public void LevelStart() => OnLevelStart?.Invoke();
    public void LevelCompleted() =>  OnLevelCompleted?.Invoke();
    public void LevelFail() =>  OnLevelFail?.Invoke();
}
