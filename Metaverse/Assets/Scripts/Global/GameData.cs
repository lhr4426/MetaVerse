using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Global
{
    [Serializable]
    public class GameData
    {
        public string date;
        public int score; 

        public GameData(string date, int score)
        {
            this.date = date;
            this.score = score;
        }

        public override string ToString()
        {
            return this.date + " | " + this.score.ToString();
        }
    }
}

