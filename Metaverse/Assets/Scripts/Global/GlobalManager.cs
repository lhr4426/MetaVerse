using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Global
{
    public enum SceneNumber
    {
        Metaverse,
        FlappyPlane,
        CodeShooter
    }



    public class GlobalManager : MonoBehaviour
    {
        public static GlobalManager instance;
        public Vector2 lastPosition;


        private void Awake()
        {
            if(instance == null)
            {
                instance = this;
                DontDestroyOnLoad(instance);
            }
            else
            {
                Destroy(this);
            }
        }

        public void SceneChange(SceneNumber sceneNumber)
        {
            
            if (sceneNumber != SceneNumber.Metaverse)
            {
                if(sceneNumber == SceneNumber.FlappyPlane) FlappyPlane.GameManager.isFirstLoading = true;
                else if(sceneNumber == SceneNumber.CodeShooter) CodeShooter.GameManager.isFirstLoading = true;


                GameObject player = FindObjectOfType<Metaverse.PlayerController>().gameObject;
                lastPosition = player.transform.position;
            }

            SceneManager.LoadScene((int)sceneNumber);
        }

        public void LeaderBoardUpdate(string sceneName, int score)
        {
            GameDatas gameDatas = LoadLeaderBoard(sceneName);
            GameData newData = new GameData();
            newData.Date = DateTime.Now;
            newData.Score = score;
            if(gameDatas.dataList == null)
            {
                gameDatas.dataList = new List<GameData>();
            }
            gameDatas.dataList.Add(newData);
            SaveLeaderBoard(sceneName, gameDatas);
            Debug.Log($"{sceneName} 게임 리더보드 {score} 추가 됨. ");
        }

        public void SaveLeaderBoard(string sceneName, GameDatas gameDatas)
        {
            string path = Application.persistentDataPath + $"/{sceneName}.json";
            File.WriteAllText(path, JsonUtility.ToJson(gameDatas));
        }

        public GameDatas LoadLeaderBoard(string sceneName)
        {
            string path = Application.persistentDataPath + $"/{sceneName}.json";
            try
            {
                FileStream fs = new(path, FileMode.Open);
                StreamReader sr = new StreamReader(fs);

                string data = sr.ReadToEnd();
                GameDatas gameDatas = JsonUtility.FromJson<GameDatas>(data);
                return gameDatas;
            }
            catch
            {
                return new GameDatas();
            }
        }

        
    }
}

