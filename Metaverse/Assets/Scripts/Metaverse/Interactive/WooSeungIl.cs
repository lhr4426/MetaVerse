using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Metaverse
{
    public class WooSeungIl : BaseNPC
    {
        protected override void Start()
        {
            base.Start();
            DateTime startDate = Convert.ToDateTime("2025/06/30 09:00");
            DateTime today = DateTime.Now;
            TimeSpan timeSpan = today - startDate;
            npcMessage = $"여기서 못 나간지 벌써 {timeSpan.Days}일째야...";
            message.text = NpcMessage;
        }
    }
}

