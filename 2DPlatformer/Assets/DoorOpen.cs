using System;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{
    private void OnEnable()
    {
        KeyNewLevel.OnDoorOpen += IsDoorOpen;
    }

    private void OnDisable()
    {
        KeyNewLevel.OnDoorOpen -= IsDoorOpen;
    }

    private void IsDoorOpen()
    {
        gameObject.SetActive(false);
    }
}
