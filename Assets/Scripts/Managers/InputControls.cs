using System;
using UnityEngine;

namespace Assets.Scripts.Managers
{
    public class InputControls : MonoBehaviour
    {
        public Action ClickPause;


        void Update()
        {
            // Klavye ESC veya joystick "Start" tuşu ile kontrol
            if (Input.GetKeyDown(KeyCode.Escape) || Input.GetButtonDown("Pause"))
            {
                ClickPause?.Invoke();
            }
        }

    }
}