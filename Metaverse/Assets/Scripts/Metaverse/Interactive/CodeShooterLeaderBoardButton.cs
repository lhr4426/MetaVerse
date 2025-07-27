using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Metaverse
{
    public class CodeShooterLeaderBoardButton : BaseInteractive
    {
        UIManager uiManager;

        private void Awake()
        {
            uiManager = FindObjectOfType<UIManager>();    
        }

        public override void Interact()
        {
            base.Interact();
            uiManager.SetLeaderBoard("CodeShooter");
        }
    }
}

