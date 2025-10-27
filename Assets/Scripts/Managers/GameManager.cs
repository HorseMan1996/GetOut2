using StarterAssets;
using UnityEngine;
namespace Assets.Scripts.Managers
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private GetGameDatas _getGameDatas;
        [SerializeField] private FirstPersonController _firstPersonController;
        void Start()
        {

        }

        void Update()
        {
            if (_getGameDatas != null)
            {
                if (_getGameDatas.GetGameState() == Enums.GameStateEnum.Paused)
                {
                    if (_firstPersonController.enabled)
                    {
                        Debug.Log("GameManager - _playerManager Active");
                        _firstPersonController.enabled = false;
                    }
                }
                else if (_getGameDatas.GetGameState() == Enums.GameStateEnum.Playing)
                {
                    if (!_firstPersonController.enabled)
                    {
                        Debug.Log("GameManager - _playerManager DeActive");
                        _firstPersonController.enabled = true;
                    }
                }
            }
        }
    }

}
