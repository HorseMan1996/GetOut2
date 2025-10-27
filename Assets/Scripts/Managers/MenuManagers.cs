using TMPro;
using UnityEngine;

namespace Assets.Scripts.Managers
{
    public class MenuManagers : MonoBehaviour
    {
        [SerializeField] private GetGameDatas _getGameDatas;

        [SerializeField] private GameObject _pauseMenuUI;
        [SerializeField] private TMP_Text _versionText;

        private void Start()
        {
            Invoke(nameof(SetVersionText), 0.1f);
        }

        void SetVersionText()
        {
            _versionText.text = _getGameDatas.GetGameVersion()[0].ToString() + "." +
                                _getGameDatas.GetGameVersion()[1].ToString() + "." +
                                _getGameDatas.GetGameVersion()[2].ToString();
        }

        void Update()
        {
            if (_getGameDatas != null)
            {
                if (_getGameDatas.GetGameState() == Enums.GameStateEnum.Paused)
                {
                    if (!_pauseMenuUI.activeSelf)
                    {
                        Debug.Log("MenuManagers - Pause Menu Active");
                        _pauseMenuUI.SetActive(true);
                    }
                }
                else if (_getGameDatas.GetGameState() == Enums.GameStateEnum.Playing)
                {
                    if (_pauseMenuUI.activeSelf)
                    {
                        Debug.Log("MenuManagers - Pause Menu DeActive");
                        _pauseMenuUI.SetActive(false);
                    }
                }
            }
        }
    }
}