using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CodeShooter
{
    public class BaseUI : MonoBehaviour
    {
        protected UIState uiState;
        public virtual UIState UiState { get { return uiState; } }

        protected UIManager uiManager;

        public virtual void Init(UIManager uiManager)
        {
            this.uiManager = uiManager;
        }



        public virtual void SetActive(UIState state)
        {
            gameObject.SetActive(UiState == state);
        }
    }
}

