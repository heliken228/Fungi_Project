using System;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private  TextMeshProUGUI coinCounterText;
    private int _coinCount = 0;
    [SerializeField] private Animator[] hearts;
    private int _currentHeartIndex = 0;

    private void Start()
    {
        foreach (var animator in hearts)
        {
            animator.SetBool("IsRed", true);
            animator.SetBool("IsGray", false);
        }
        CoinCounter();
    }

    public void AddCoin()
    {
        _coinCount++;
        CoinCounter();
    }

    private void CoinCounter()
    {
        coinCounterText.text = _coinCount.ToString();
    }
    
    private void OnEnable()
    {
        DamagePlayer.OnTakeDamage += IsTakeDamage;
    }

    private void IsTakeDamage()
    {
        if (_currentHeartIndex < hearts.Length)
        {
            hearts[_currentHeartIndex].SetBool("IsRed", false);
            hearts[_currentHeartIndex].SetBool("IsGray", true);
            _currentHeartIndex++;
            if (_currentHeartIndex >= hearts.Length)
            {
                Player.Instance.Death();
            }
        }
    }
    private void OnDisable()
    {
        DamagePlayer.OnTakeDamage -= IsTakeDamage;
    }

}
