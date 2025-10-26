using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Managers
{
    public class GetGameDatas : MonoBehaviour
    {
        
        private void Start()
        {
            GameStateEnum gameStateEnum = Resources.Load<RD_GameState>("RD_GameState").CurrentState;
        }
    }
}