using System;
using UnityEngine;

public class CoinTrigger : MonoBehaviour
{
    public static Action<bool> OnCoinTriggered;
    
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            OnCoinTriggered?.Invoke(true);
            gameObject.SetActive(false);
        }
    }
}
