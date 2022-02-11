using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// このネームスペースはキャラクター周りを書く時に使おう
/// </summary>
namespace Junjun.Character
{
    /// <summary>
    /// Playerの動き
    /// </summary>
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerController : MonoBehaviour
    {
        /// <summary>力の加え方</summary>
        [SerializeField] MoveType m_moveType = MoveType.AddForce;

        /// <summary>Playerの動くスピード</summary>
        [SerializeField] float m_speed = 1.0f;

        /// <summary>動く方向</summary>
        Vector3 m_dir;

        Rigidbody m_rb;

        private void Start()
        {
            m_rb = GetComponent<Rigidbody>();
        }

        private void Update()
        {
            float v = Input.GetAxisRaw("Vertical");
            float h = Input.GetAxisRaw("Horizontal");

            m_dir = Vector3.forward * v + Vector3.right * h;
        }

        private void FixedUpdate()
        {
            if (m_dir != Vector3.zero)
            {
                if (m_moveType == MoveType.AddForce)
                {
                    m_rb.AddForce(m_dir * m_speed, ForceMode.Force);
                }
                else if (m_moveType == MoveType.Velocity)
                {
                    m_rb.velocity = m_dir * m_speed;
                }
            }
        }
    }

    /// <summary>
    /// 動かす方法をこのEnumで変える
    /// </summary>
    public enum MoveType
    {
        AddForce, Velocity
    }
}