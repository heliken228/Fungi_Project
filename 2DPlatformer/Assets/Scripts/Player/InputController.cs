using System;
using UnityEngine;

    public class InputController : MonoBehaviour
    {
        private float _horizontalInput;
        public delegate void HorizontalInputAction();
        public static HorizontalInputAction horizontalInputAction;
        
        public delegate void VerticalInputAction();
        public static VerticalInputAction verticalInputAction;

        void Update()
        {
            _horizontalInput = Input.GetAxis("Horizontal");
            if (_horizontalInput != 0)
            {
                horizontalInputAction?.Invoke();
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                verticalInputAction?.Invoke();
            }
        }
        

       
    }
