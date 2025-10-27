using Assets.Scripts.DataScripts.CD_Data;
using Assets.Scripts.DataScripts.RD_Data;
using Assets.Scripts.Enums;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Managers
{
    public class GetGameDatas : MonoBehaviour
    {
        private RD_GameState GameStateEnumData;
        private CD_GameVersion GameVersionData;

        private void Start()
        {
            GameStateEnumData = Resources.Load<RD_GameState>("RD_GameState");
            GameVersionData = Resources.Load<CD_GameVersion>("CD_GameVersion");
            InputControls.Instance.ClickPauseEvent += SetCurrentGameStatePauseOrPlay;
        }

        private void OnDisable()
        {
            InputControls.Instance.ClickPauseEvent -= SetCurrentGameStatePauseOrPlay;
        }

        private void SetCurrentGameStatePauseOrPlay()
        {
          
            if (GameStateEnumData.CurrentState == GameStateEnum.Playing)
            {
                Debug.Log("GameStateEnum.Paused");
                GameStateEnumData.CurrentState = GameStateEnum.Paused;
            }
            else
            {
                Debug.Log("GameStateEnum.Playing");
                GameStateEnumData.CurrentState = GameStateEnum.Playing;
            }
        }

        public List<byte> GetGameVersion()
        {
            return GameVersionData.GameVersion;
        }

        public GameStateEnum GetGameState()
        {
            return GameStateEnumData.CurrentState;
        }
    }
}