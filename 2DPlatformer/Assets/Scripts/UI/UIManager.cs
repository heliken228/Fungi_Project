using System;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private  TextMeshProUGUI coinCounterText;
    private int coinCount = 0;

    private void Start()
    {
        CoinCounter();
    }

    public void AddCoin()
    {
        coinCount++;
        CoinCounter();
    }

    private void CoinCounter()
    {
        coinCounterText.text = coinCount.ToString();
    }
}
