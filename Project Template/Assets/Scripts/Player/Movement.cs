using UnityEngine;

public class Movement : CostumBehaviour
{
    [SerializeField] private Transform playerMesh;
    [SerializeField] private float horizontalSpeed, verticalSpeed;
    
    private bool m_ForwardMove;
    private bool m_HorizontalMov;
    private Vector3 m_PlayerMeshPos;
    private Vector3 m_PreviousMousePos;
    private Vector3 m_SmoothVelocity = Vector3.zero;
    private Player m_Player;

    private void Start()
    {
        m_Player = GetComponent<Player>();
        m_Player.GameStart += GameStart;
    }

    private void Update()
    {
        PlayerMovement();
    }

    #region Hyper Casual Movement

    private void PlayerMovement()
    {
        MousePosCheck();
        
        if (m_ForwardMove) transform.position += Vector3.forward * verticalSpeed * Time.deltaTime;
        
        if (m_HorizontalMov) playerMesh.localPosition =
            Vector3.SmoothDamp(playerMesh.localPosition, m_PlayerMeshPos, ref m_SmoothVelocity, 0.1f);
    }
    private void MousePosCheck()
    {
        if (Input.GetMouseButtonDown(0))
        {
            m_PreviousMousePos = Input.mousePosition;
        }
        else if (Input.GetMouseButton(0))
        {
            if (!m_HorizontalMov) return;
            var mouseViewPos = CameraManager.mainCamera.ScreenToViewportPoint(m_PreviousMousePos - Input.mousePosition);
            m_PlayerMeshPos += Vector3.left * (mouseViewPos.x * horizontalSpeed);
            var clampedPlayerMeshPosX = Mathf.Clamp(m_PlayerMeshPos.x, -4.5f, 4.5f);
            m_PlayerMeshPos.Set(clampedPlayerMeshPosX, m_PlayerMeshPos.y, m_PlayerMeshPos.z);
            m_PreviousMousePos = Input.mousePosition;
        }
    }

    #endregion
    #region Delegetes

    private void GameStart()
    {
        m_HorizontalMov = true;
        m_ForwardMove = true;
    }

    #endregion
}
