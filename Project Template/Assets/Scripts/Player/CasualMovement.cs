using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CasualMovement : MonoBehaviour
{
    [SerializeField] private float rotateSpeed, movementSpeed;
    private Rigidbody Rigid => GetComponent<Rigidbody>();
    
    private Vector3 m_MoveDirection;
    private float m_Horizontal;
    private float m_Vertical;
    private bool m_Movement;
    private void Update()
    {
        InputData();
       // TransformMovement();
    }
    private void FixedUpdate()
    {
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
    
}
