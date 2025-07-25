using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Metaverse
{
    public enum SceneNumber
    {
        Metaverse,
        FlappyPlane
    }



    public class GlobalManager : MonoBehaviour
    {
        public static GlobalManager instance;

        private void Awake()
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }

        public void SceneChange(SceneNumber sceneNumber)
        {
            SceneManager.LoadScene((int)sceneNumber);
        }
    }
}

