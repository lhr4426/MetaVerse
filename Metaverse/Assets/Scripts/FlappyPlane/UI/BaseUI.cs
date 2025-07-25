using FlappyPlane;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FlappyPlane
{
    public abstract class BaseUI : MonoBehaviour
    {
        protected UIState uiState;
        public virtual UIState UiState { get { return uiState; } }

        protected UIManager uiManager;
        public void Init(UIManager uiManager)
        {
            this.uiManager = uiManager;
        }

        public virtual void SetActive(UIState uiState)
        {
            gameObject.SetActive(UiState == uiState);
        }
    }
}

