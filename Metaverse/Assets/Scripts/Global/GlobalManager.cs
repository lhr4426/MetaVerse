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
            GameData newData = new GameData(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), score);
            if (gameDatas == null) gameDatas = new GameDatas();
            if (gameDatas.DataList == null) gameDatas.DataList = new();

            Debug.Log($"{newData.ToString()}");

            gameDatas.DataList.Add(newData);
            SaveLeaderBoard(sceneName, gameDatas);
            Debug.Log($"{sceneName} 게임 리더보드 {score} | {newData.Date} 추가 됨. ");
        }

        public void SaveLeaderBoard(string sceneName, GameDatas gameDatas)
        {
            string path = Application.persistentDataPath + $"/{sceneName}.json";

            try
            {
                StreamWriter sw = new(path, false);
                sw.Write(JsonUtility.ToJson(gameDatas));
            }
            catch (Exception e)
            {
                Debug.LogError($"{e}");
            }
        }

        public GameDatas LoadLeaderBoard(string sceneName)
        {
            string path = Application.persistentDataPath + $"/{sceneName}.json";
            FileStream fs;
            try
            {
                fs = new(path, FileMode.Open);
            }
            catch (Exception e)
            {
                fs = new FileStream(path, FileMode.Create);
            }
            
            try
            {
                
                StreamReader sr = new StreamReader(fs);

                string data = sr.ReadToEnd();
                GameDatas gameDatas = JsonUtility.FromJson<GameDatas>(data);
                
                return gameDatas;
            }
            catch
            {
                Debug.LogError("Json Parse Error");
                return new GameDatas();
            }
            finally
            {
                fs.Close();
            }
        }

        
    }
}

