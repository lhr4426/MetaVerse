using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Global
{
    [Serializable]
    public class GameData
    {
        public string Date { get; set; }
        public int Score { get; set; }

        public GameData(string date, int score)
        {
            this.Date = date;
            this.Score = score;
        }

        public override string ToString()
        {
            return this.Date + " | " + this.Score.ToString();
        }
    }
}

