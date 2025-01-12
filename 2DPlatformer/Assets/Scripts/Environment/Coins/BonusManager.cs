using System;
using TMPro;
using UnityEngine;

public class BonusManager : MonoBehaviour
{
    [SerializeField] private UIManager _uiManager;
    public TextMeshProUGUI coinCounterText;
    private int coinCount = 0; 

    void Start()
    {
        UpdateCoinCounter();
    }

    public void AddCoin()
    {
        coinCount++;
        UpdateCoinCounter();
    }

    private void UpdateCoinCounter()
    {
        coinCounterText.text = coinCount.ToString();
    }
    
}
