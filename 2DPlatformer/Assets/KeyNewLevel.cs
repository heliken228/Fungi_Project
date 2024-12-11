using System;
using UnityEngine;

public class KeyNewLevel : MonoBehaviour
{
    public static Action OnDoorOpen;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            OnDoorOpen?.Invoke();
            gameObject.SetActive(false);
        }
    }
}
