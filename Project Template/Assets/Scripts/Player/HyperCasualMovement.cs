using UnityEngine;

public class HyperCasualMovement : CostumBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private Transform playerMesh;
    [SerializeField] private float horizontalSpeed, verticalSpeed;

    private bool m_VerticalMove;
    private bool m_HorizontalMov;
    
    private Vector3 m_PlayerMeshPos;
    private Vector3 m_PreviousMousePos;
    private Vector3 m_SmoothVelocity = Vector3.zero;
    
    private void Awake()
    {
        PlayerManager.MovementActivate += ActiveMovement;
        PlayerManager.MovementDeActivate += DeActiveMovement;
        PlayerManager.AnimationChange += AnimationChange;
    }
    private void Update()
    {
        PlayerMovement();
    }
    private void PlayerMovement()
    {
        if (m_VerticalMove)
        {
            transform.position += Vector3.forward * verticalSpeed * Time.deltaTime;
        }
    
        if (m_HorizontalMov)
        {
            MousePosCheck();
            playerMesh.localPosition =
                Vector3.SmoothDamp(playerMesh.localPosition, m_PlayerMeshPos, ref m_SmoothVelocity, 0.1f);
        }
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
    
    #region TASK
    private void AnimationChange(string animName, float normalizedTime = 0.1f, int layer = 0)
    {
        animator.CrossFade(animName, normalizedTime, layer);
    }
    private void ActiveMovement(bool horizontal, bool vertical)
    {
        if (horizontal & !m_HorizontalMov) m_HorizontalMov = true;
        if (vertical & !m_VerticalMove)  m_VerticalMove = true; 
    }
    private void DeActiveMovement(bool horizontal, bool vertical)
    {
        if (horizontal & m_HorizontalMov) m_HorizontalMov = false;
        if (vertical & m_VerticalMove) m_VerticalMove = false; 
    }
    
    #endregion
}
