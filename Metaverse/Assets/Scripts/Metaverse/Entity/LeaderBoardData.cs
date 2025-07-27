using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Metaverse
{
    public class LeaderBoardData : MonoBehaviour
    {
        public TextMeshProUGUI scoreText;
        public TextMeshProUGUI timeText;

        public void SetText(Global.GameData data)
        {
            scoreText.text = data.score.ToString() + "Á¡";
            timeText.text = data.date;
        }
    }
}

