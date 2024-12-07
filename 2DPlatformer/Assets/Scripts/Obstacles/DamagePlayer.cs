using System;
using UnityEngine;

public class DamagePlayer : MonoBehaviour
{
    public static Action OnTakeDamage;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Debug.Log("Damage Player");
            OnTakeDamage?.Invoke();
        }
    }
}
