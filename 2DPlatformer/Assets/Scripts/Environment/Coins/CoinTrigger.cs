using System;
using UnityEngine;

public class CoinTrigger : MonoBehaviour
{
    public static Action<bool> OnCoinTriggered;
    public BonusManager coinCounter;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            coinCounter.AddCoin();
            OnCoinTriggered?.Invoke(true);
            gameObject.SetActive(false);
        }
    }
}
