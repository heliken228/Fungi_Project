using System;
using UnityEditor.Tilemaps;
using UnityEngine;

    public class InputController : MonoBehaviour
    {
        void Update()
        {
            Player.Instance.Move(Input.GetAxisRaw("Horizontal"));

            if (Input.GetKeyDown(KeyCode.Space))
            {
                Player.Instance.Jump();
            }
        }
    }