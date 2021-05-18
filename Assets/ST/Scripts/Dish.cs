using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dish : MonoBehaviour
{
    /// <summary>ScoreManagerのオブジェクト</summary>
    [SerializeField] ScoreManager m_ScoreManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Coin")
        {

        }
    }
}
