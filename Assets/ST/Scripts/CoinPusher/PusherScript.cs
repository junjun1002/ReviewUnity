using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Pusherを動かすクラス
/// </summary>
public class PusherScript : MonoBehaviour
{
    /// <summary>初期位置</summary>
    Vector3 initPosition;
    /// <summary>移動するごとの位置</summary>
    Vector3 newPosition;

    Rigidbody m_rb;
    void Start()
    {
        // 初期位置はゲームが始まった時の位置
        initPosition = this.transform.position;

        m_rb = GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    void Update()
    {
        // Sin関数は-1～1の間を繰り返す関数 これでZ軸方向に初期位置から-1～1を毎フレームごとに更新されている
        newPosition = new Vector3(initPosition.x, initPosition.y, initPosition.z + Mathf.Sin(Time.time));
        // MovePositionは指定された位置に動く関数
        m_rb.MovePosition(newPosition);
    }

}
