using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Breakout
{
    public class PlayerBar : MonoBehaviour
    {
        /// <summary>Playerが動くときに力を加えるか、速度を操作するか</summary>
        [SerializeField] MoveType m_moveType = MoveType.AddForce;
        /// <summary>動く時のスピード</summary>
        [SerializeField] float m_moveSpeed = 1.0f;

        Rigidbody m_rb;

        void Start()
        {
            m_rb = GetComponent<Rigidbody>();
        }

        private void Update()
        {
            // 方向の入力を取得し、方向を求める　縦方向はVerticalで入力を取得できる
            float h = Input.GetAxisRaw("Horizontal");
            // dirはdirectionの略、意味は方向
            // Vector3.rightはVector3(1, 0, 0)と同じ意味、入力に対して力を加えている
            Vector3 dir = Vector3.right * h;

            // 入力があれば、そちらの方向に動かす　
            // ！＝イコールじゃないよの意味
            // ifはもし～
            if (dir != Vector3.zero)
            {
                // 自分が動く方向の向きを代入している
                this.transform.right = dir;
                // Enumに関しては個人的Debugをしやすくするために使ってるので割愛（個人で聞いてくれたら答えます）
                if (m_moveType == MoveType.AddForce)
                {
                    // Spawnerの動きをAddForceで動かす場合
                    // AddForceはどんどん力加えていく関数、この場合だと動く向きにスピードを加算している
                    m_rb.AddForce(this.transform.right * m_moveSpeed);
                }
                else if (m_moveType == MoveType.Velocity)
                {
                    // Spawnerの動きをvelocityで動かす場合
                    // velocityは入力されたスピードで一定に動く関数
                    m_rb.velocity = this.transform.right * m_moveSpeed;
                }
            }
        }
    }
    public enum MoveType
    {
        AddForce, Velocity
    }
}

