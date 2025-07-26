using Metaverse;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace CodeShooter
{
    public class PauseUI : BaseUI
    {
        [SerializeField] private Button exitButton;
        public override UIState UiState => UIState.Pause;
        private void Start()
        {
            exitButton.onClick.RemoveAllListeners();

            exitButton.onClick.AddListener(OnClickExit);
        }
        public void OnClickExit()
        {
            GlobalManager.instance.SceneChange(SceneNumber.Metaverse);
        }
    }
}

