using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Metaverse
{
    public class AngelChest : BaseInteractive
    {
        private PlayerController playerController;
        [SerializeField] private Sprite angleSprite;

        private void Start()
        {
            playerController = GameManager.instance.Player.GetComponent<PlayerController>();
        }
        public override void Interact()
        {
            base.Interact();
            playerController.MountSetting(angleSprite);
        }
    }
}

