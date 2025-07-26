using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Metaverse
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


                GameObject player = FindObjectOfType<PlayerController>().gameObject;
                lastPosition = player.transform.position;
            }
            SceneManager.LoadScene((int)sceneNumber);

        }

        
    }
}

