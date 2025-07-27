using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Metaverse 
{
    public class UIManager : MonoBehaviour
    {
        private UIManager instance;
        public UIManager Instance { get; private set; }

        public TextMeshProUGUI roomText;

        public LeaderBoard leaderBoard;

        private void Awake()
        {
            instance = this;

            BaseRoom[] Rooms = FindObjectsByType<BaseRoom>(sortMode: FindObjectsSortMode.None);

            foreach (var rooms in Rooms)
            {
                rooms.Init(this);
            }
        }

        public void EnterRoom(string roomName)
        {
            roomText.text = roomName;
        }

        public void ExitRoom()
        {
            roomText.text = "";
        }

        public void SetLeaderBoard(string sceneName)
        {
            leaderBoard.gameObject.SetActive(true);
            leaderBoard.SetTitle(sceneName);

            Global.GameDatas gameDatas = Global.GlobalManager.instance.LoadLeaderBoard(sceneName);
            leaderBoard.AddDatas(gameDatas);
        }
    }

}


