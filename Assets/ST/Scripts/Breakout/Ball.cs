using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Breakout
{
    public class Ball : MonoBehaviour
    {
        [SerializeField] float m_speed = 5.0f;

        [SerializeField] float m_maxSpeed = 10f;

        Rigidbody m_rb;

        private void Start()
        {
            m_rb = GetComponent<Rigidbody>();
            m_rb.AddForce((transform.forward + transform.right) * m_speed, ForceMode.VelocityChange);
        }

        
    }
}