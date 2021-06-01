using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 受け皿のスクリプト
/// こいつにCoinが触れたらコインは消えて、スコアを加算する
/// </summary>
public class Dish : MonoBehaviour
{
    /// <summary>ScoreManagerのオブジェクト</summary>
    [SerializeField] ScoreManager m_ScoreManager;
    /// <summary>コインのスコア</summary>
    [SerializeField] int m_score = 1;
    /// <summary>コインのSE</summary>
    [SerializeField] AudioClip m_coinSE;
    /// <summary>音を鳴らすためのオーディオソース</summary>
    [SerializeField]　AudioSource m_audio;

    /// <summary>
    /// OnTriggerEnterはトリガーに触れた時の処理を記述する関数
    /// OnCollisionEnterとの違いはまた別で説明
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        // otherが触れたオブジェクト
        // 触れたオブジェクトがCoinだった時の処理
        if (other.gameObject.tag == "Coin")
        {
            // Destroyは意味どうりに破壊する
            // この場合は触れてきたオブジェクト（if内に記述することでこの場合だとコインを消す）
            Destroy(other.gameObject);
            // スコアを加算する関数を呼び出し
            m_ScoreManager.AddScore(m_score);
            // スコアが加算される毎に音が鳴る
            PlaySE(m_coinSE);
        }
    }

    /// <summary>
    /// SEを鳴らすスクリプト
    /// </summary>
    void PlaySE(AudioClip sE)
    {
        // SEを鳴らす関数
        m_audio.PlayOneShot(sE);
    }
}
