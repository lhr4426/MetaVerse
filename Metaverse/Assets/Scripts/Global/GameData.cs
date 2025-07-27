using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Global
{
    [Serializable]
    public struct GameData
    {
        public DateTime Date { get; set; }
        public int Score { get; set; }

        public GameData(DateTime date, int score)
        {
            this.Date = date;
            this.Score = score;
        }
    }
}

