using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Metaverse
{
    public class LeaderBoard : MonoBehaviour
    {
        public Transform contents;
        public GameObject dataPrefab;
        public TextMeshProUGUI titleText;
        public GameObject noDataText;

        private List<GameObject> gameObjects = new();

        public void AddDatas(Global.GameDatas gameDatas)
        {
            if (gameDatas == null || gameDatas.dataList == null)
            {
                noDataText.SetActive(true);
                return;
            }
            foreach (var data in gameDatas.dataList)
            {
                noDataText.SetActive(false);
                GameObject go = Instantiate(dataPrefab, contents);
                LeaderBoardData leaderBoardData = go.GetComponent<LeaderBoardData>();
                leaderBoardData.SetText(data);
                gameObjects.Add(go);
            }
        }

        public void SetTitle(string gameName)
        {
            titleText.text = gameName;
        }

        public void OnClickExit()
        {
            if(gameObjects.Count > 0)
            {
                foreach(var data in gameObjects)
                {
                    Destroy(data);
                }
            }
            gameObject.SetActive(false);
        }
    }


}
