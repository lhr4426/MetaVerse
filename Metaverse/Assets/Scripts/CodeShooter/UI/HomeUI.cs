using Metaverse;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CodeShooter
{
    public class HomeUI : BaseUI
    {
        [SerializeField] private Button startButton;
        [SerializeField] private Button exitButton;

        public override UIState UiState => UIState.Home;

        private void Start()
        {
            startButton.onClick.RemoveAllListeners();
            exitButton.onClick.RemoveAllListeners();

            startButton.onClick.AddListener(OnClickStart);
            exitButton.onClick.AddListener(OnClickExit);
        }

        public void OnClickStart()
        {
            uiManager.StartButton();
        }

        public void OnClickExit()
        {
            GlobalManager.instance.SceneChange(SceneNumber.Metaverse);
        }
    }
}


