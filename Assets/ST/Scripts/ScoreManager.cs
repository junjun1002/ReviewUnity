using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{

    [SerializeField] int m_score = 1;

    [SerializeField] Text m_scoreText;

    int m_currentScore;

    public void AddScore()
    {
        m_currentScore += m_score;
        m_scoreText.text = m_currentScore.ToString();
    }
}
