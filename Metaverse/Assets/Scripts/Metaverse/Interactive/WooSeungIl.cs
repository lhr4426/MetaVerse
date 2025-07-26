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
            npcMessage = $"���⼭ �� ������ ���� {timeSpan.Days}��°��...";
            message.text = NpcMessage;
        }
    }
}

