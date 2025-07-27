using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Metaverse
{
    public class Weapon : BaseInteractive
    {
        private SpriteRenderer spriteRenderer;
        private PlayerController playerController;

        private void Awake()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
        }

        private void Start()
        {
            playerController = GameManager.instance.Player.GetComponent<PlayerController>();
        }
        public override void Interact()
        {
            base.Interact();
            playerController.WeaponSetting(spriteRenderer.sprite);
        }
    }
}

