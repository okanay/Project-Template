using UnityEngine;

public class CostumBehaviour : MonoBehaviour
{
    private GameManagers GameManagers => GameManagers.Instance;
    protected EventManager EventManager => GameManagers.EventManager;
        
    protected PlayerManager PlayerManager => GameManagers.PlayerManager;
        
    protected LevelManager LevelManager => GameManagers.LevelManager;

    protected CanvasManager CanvasManager => GameManagers.CanvasManager;
        
    protected CameraManager CameraManager => GameManagers.CameraManager;
    
}
