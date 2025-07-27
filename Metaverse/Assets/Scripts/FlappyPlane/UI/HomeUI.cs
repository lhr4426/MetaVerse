using Metaverse;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace FlappyPlane
{
    public class HomeUI : BaseUI
    {
        public Button startButton;
        public Button exitButton;

        public override UIState UiState => UIState.Home;


        // Start is called before the first frame update
        void Start()
        {   
            // Ȥ�� ���� �ʱ�ȭ

            startButton.onClick.RemoveAllListeners();
            exitButton.onClick.RemoveAllListeners();

            startButton.onClick.AddListener(OnClickStart);
            exitButton.onClick.AddListener(OnClickExit);
        }


        public override void SetActive(UIState uiState)
        {
            base.SetActive(uiState);
            Time.timeScale = 0;
        }

        public void OnClickStart()
        {
            uiManager.GameStart();
        }

        public void OnClickExit()
        {
            Global.GlobalManager.instance.SceneChange(Global.SceneNumber.Metaverse);
        }
        
    }

}
