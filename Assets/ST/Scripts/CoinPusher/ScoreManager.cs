using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// スコアに関する処理を管理するクラス
/// </summary>
public class ScoreManager : MonoBehaviour
{
    /// <summary>スコアを表示するテキスト</summary>
    [SerializeField] Text m_scoreText;
    /// <summary>現在のスコア</summary>
    int m_currentScore;

    /// <summary>
    /// スコアを加算する関数
    /// </summary>
    /// <param name="score"></param>
    public void AddScore(int score)
    {
        // 関数が呼ばれるたびに現在のスコアを加算
        m_currentScore += score;
        // スコアが更新されるたびにテキストも更新
        // ToStringはString型に変更する関数
        m_scoreText.text = m_currentScore.ToString();
    }
}
