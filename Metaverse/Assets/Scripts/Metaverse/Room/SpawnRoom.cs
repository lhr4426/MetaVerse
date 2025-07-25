using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Metaverse
{
    public class SpawnRoom : BaseRoom
    {
        public override void Init(UIManager uiManager)
        {
            base.Init(uiManager);
            RoomName = "스폰 장소";
        }
    }
}

