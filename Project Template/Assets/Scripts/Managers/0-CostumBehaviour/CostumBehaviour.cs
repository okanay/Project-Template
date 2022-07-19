using UnityEngine;
// ReSharper disable All

public class CostumBehaviour : MonoBehaviour
{
    private GameManagers GameManagers => GameManagers.Instance;
    protected EventManager EventManager => GameManagers.EventManager;
    protected PlayerManager PlayerManager => GameManagers.PlayerManager;
        
    protected LevelManager LevelManager => GameManagers.LevelManager;

    protected CanvasManager CanvasManager => GameManagers.CanvasManager;
    protected CameraManager CameraManager => GameManagers.CameraManager;

    public delegate void MovementState(bool horizontal = true, bool vertical = true); // hyperCasual

    public delegate void AnimationState(string animName, float normalizedTime = 0.1f, int layer = 0); // hyperCasual

    public const string Pose = "T-Pose";
    public const string Run = "Run";
    public const string Idle = "Idle";
}
