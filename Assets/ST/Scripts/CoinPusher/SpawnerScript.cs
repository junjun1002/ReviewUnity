using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Spawnerを動かすスクリプト
/// </summary>
public class SpawnerScript : MonoBehaviour
{
    // [SerializeField]はインスペクターから操作出来るようにするもの
    // 変数の前にm_を書くのはメンバ変数だから

    /// <summary>Playerが動くときに力を加えるか、速度を操作するか</summary>
    [SerializeField] MoveType m_moveType = MoveType.AddForce;
    /// <summary>動く時のスピード</summary>
    [SerializeField] float m_moveSpeed = 1.0f;
    /// <summary>Coinのプレハブ</summary>
    [SerializeField] GameObject m_coin;
    /// <summary>スポーン位置のプレハブ</summary>
    [SerializeField] GameObject m_spawnPoint;


    Rigidbody m_rb;

    // Start is called before the first frame update
    void Start()
    {
        m_rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
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
            this.transform.forward = dir;
            // Enumに関しては個人的Debugをしやすくするために使ってるので割愛（個人で聞いてくれたら答えます）
            if (m_moveType == MoveType.AddForce)
            {
                // Spawnerの動きをAddForceで動かす場合
                // AddForceはどんどん力加えていく関数、この場合だと動く向きにスピードを加算している
                m_rb.AddForce(this.transform.forward * m_moveSpeed);
            }
            else if (m_moveType == MoveType.Velocity)
            {
                // Spawnerの動きをvelocityで動かす場合
                // velocityは入力されたスピードで一定に動く関数
                m_rb.velocity = this.transform.forward * m_moveSpeed;
            }
        }
        // Spaceキーが押されたら
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Instantiateは生成の意味
            // Instantiate(生成したいもの, 生成する位置, 生成するときの回転値)
            Instantiate(m_coin, m_spawnPoint.transform.position, m_spawnPoint.transform.rotation);
        }
    }
}

public enum MoveType
{
    AddForce, Velocity
}
