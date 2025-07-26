using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Metaverse
{
public class CodeShooterButton : BaseInteractive
{
        public override void Interact()
        {
            base.Interact();
            GlobalManager.instance.SceneChange(SceneNumber.CodeShooter);
        }
    }
}

