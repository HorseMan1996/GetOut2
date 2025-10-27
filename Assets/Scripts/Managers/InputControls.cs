using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Assets.Scripts.Managers
{
    public class InputControls : MonoBehaviour
    {

        public InputAction ClickPause;

        public Action ClickPauseEvent;

        public static InputControls Instance { get; private set; }

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }
        private void OnEnable()
        {
            ClickPause.Enable();
            ClickPause.performed += ctx => TogglePause();
        }

        private void OnDisable()
        {
            ClickPause.performed -= ctx => TogglePause();
            ClickPause.Disable();
        }

        private void TogglePause()
        {
            Debug.Log("InputControls - TogglePause Invoked");
            ClickPauseEvent?.Invoke();
        }

        void Update()
        {
            if (Gamepad.current != null && Gamepad.current.startButton.wasPressedThisFrame)
            {
                Debug.Log("GamePad Esc Click");
                //ClickPause?.Invoke();
            }
            if (Keyboard.current.escapeKey.wasPressedThisFrame)
            {
                Debug.Log("Keyboard Esc Click");
                //ClickPause?.Invoke();
            }
        }

    }
}