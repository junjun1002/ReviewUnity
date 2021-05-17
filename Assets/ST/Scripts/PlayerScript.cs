using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Playerを動かすスクリプト
/// </summary>
public class PlayerScript : MonoBehaviour
{
    /// <summary>Playerが動くときに力を加えるか、速度を操作するか</summary>
    [SerializeField] MoveType m_moveType = MoveType.AddForce;
    /// <summary>動く時のスピード</summary>
    [SerializeField] float m_moveSpeed = 1.0f;

    Rigidbody m_rb;

    // Start is called before the first frame update
    void Start()
    {
        m_rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // 方向の入力を取得し、方向を求める
        float v = Input.GetAxisRaw("Vertical");
        float h = Input.GetAxisRaw("Horizontal");
        Vector3 dir = (Vector3.forward * v + Vector3.right * h).normalized;

        // 入力があれば、そちらの方向に動かす
        if (dir != Vector3.zero)
        {
            this.transform.forward = dir;
            if (m_moveType == MoveType.AddForce)
            {
                m_rb.AddForce(this.transform.forward * m_moveSpeed);
            }
            else if (m_moveType == MoveType.Velocity)
            {
                m_rb.velocity = this.transform.forward * m_moveSpeed;
            }
        }
    }
}

public enum MoveType
{
    AddForce, Velocity
}
