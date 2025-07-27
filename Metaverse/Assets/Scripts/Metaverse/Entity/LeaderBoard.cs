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

        public void AddDatas(Global.GameDatas gameDatas)
        {
            if (gameDatas == null || gameDatas.DataList == null)
            {
                noDataText.SetActive(true);
                return;
            }
            foreach (var data in gameDatas.DataList)
            {
                noDataText.SetActive(false);
                GameObject go = Instantiate(dataPrefab, contents);
                LeaderBoardData leaderBoardData = go.GetComponent<LeaderBoardData>();
                leaderBoardData.SetText(data);
            }
        }

        public void SetTitle(string gameName)
        {
            titleText.text = gameName;
        }

    }


}
