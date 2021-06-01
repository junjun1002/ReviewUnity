using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Coinが受け皿を外して落ちた時
/// </summary>
public class OutErea : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Coin")
        {
            Destroy(other.gameObject);
        }
    }
}
