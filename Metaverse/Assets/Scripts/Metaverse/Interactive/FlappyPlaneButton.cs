using FlappyPlane;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Metaverse
{
    public class FlappyPlaneButton : BaseInteractive
    {
        public override void Interact()
        {
            base.Interact();
            Global.GlobalManager.instance.SceneChange(Global.SceneNumber.FlappyPlane);
        }
    }
}

