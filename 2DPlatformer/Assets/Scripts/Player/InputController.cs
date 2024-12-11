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
            if (Input.GetKeyDown(KeyCode.F))
            {
                Player.Instance.Attack();
            }
            if (Input.GetKeyDown(KeyCode.H))
            {
                Player.Instance.StartBlock();
            }
            if (Input.GetKeyUp(KeyCode.H))
            {
                Player.Instance.StopBlock();
            }
        }
    }
