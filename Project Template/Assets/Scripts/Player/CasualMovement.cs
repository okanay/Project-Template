using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CasualMovement : CostumBehaviour
{
    [SerializeField]
    private float rotateSpeed;
    
    [SerializeField]
    private float movementSpeed;
    private Rigidbody Rigid =>
        GetComponent<Rigidbody>(); 
    private Animator Animator =>
        GetComponent<Animator>();
    
    private Vector3 m_MoveDirection;
    private float m_Horizontal;
    private float m_Vertical;
    private bool m_RigidbodyMovement;
    private bool m_TransformMovement;
    
    private void Awake()
    {
        PlayerManager.MovementActivate += ActiveMovement;
        PlayerManager.MovementDeActivate += DeActiveMovement;
        PlayerManager.AnimationChange += AnimationChange;
    }
    private void Update()
    {
        InputData();

        if (!m_TransformMovement) return;
         TransformMovement();
    }
    private void FixedUpdate()
    {
        if (!m_RigidbodyMovement) return;
        RigidbodyMovement();
    }

    private void InputData()
    {
        m_Horizontal = Input.GetAxisRaw("Horizontal");
        m_Vertical = Input.GetAxisRaw("Vertical");
        m_MoveDirection = new Vector3(m_Horizontal, 0, m_Vertical);
        m_MoveDirection.Normalize();
    }
    private void TransformMovement()
    {
        transform.Translate(m_MoveDirection * Time.deltaTime * movementSpeed, Space.World);

        if (m_MoveDirection != Vector3.zero)
        {
            var targetRotation = Quaternion.LookRotation(m_MoveDirection, Vector3.up);
            transform.rotation =
                Quaternion.RotateTowards(transform.rotation, targetRotation, rotateSpeed * Time.deltaTime * 100);
        }
    }
    private void RigidbodyMovement()
    {
        Rigid.MovePosition(transform.position + m_MoveDirection * Time.deltaTime * movementSpeed);
        
        if (m_MoveDirection != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(m_MoveDirection, Vector3.up);
            Rigid.MoveRotation( Quaternion.RotateTowards(transform.rotation, targetRotation, rotateSpeed * Time.deltaTime * 100));
        }
    }
    
    #region TASK
    private void AnimationChange(string animName, float normalizedTime = 0.1f, int layer = 0)
    {
        Animator.CrossFade(animName, normalizedTime, layer);
    }
    private void ActiveMovement(bool rigidbodyMovement, bool transformMovement)
    {
        if (rigidbodyMovement & !m_RigidbodyMovement) m_RigidbodyMovement = true;
        if (transformMovement & !m_TransformMovement) m_TransformMovement = true;
    }
    private void DeActiveMovement(bool rigidbodyMovement, bool transformMovement)
    {
        if (rigidbodyMovement & m_RigidbodyMovement) m_RigidbodyMovement = false;
        if (transformMovement & m_TransformMovement) m_TransformMovement = false;
    }
    
    #endregion
}
