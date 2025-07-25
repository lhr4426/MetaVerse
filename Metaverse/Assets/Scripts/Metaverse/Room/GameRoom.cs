using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Metaverse
{
    public class GameRoom : BaseRoom
    {
        public override void Init(UIManager uiManager)
        {
            base.Init(uiManager);
            RoomName = "미니게임존";
        }
    }
}

