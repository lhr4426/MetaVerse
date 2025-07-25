using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Metaverse
{
    public abstract class BaseRoom : MonoBehaviour
    {
        private string roomName;
        public virtual string RoomName { get => roomName; set => roomName = value; }

        private UIManager uiManager;

        public virtual void Init(UIManager uiManager)
        {
            this.uiManager = uiManager;
        }
        protected virtual void EnterRoom()
        {
            Debug.Log($"{RoomName} ¿‘¿Â");
            uiManager.EnterRoom(RoomName);
            return;
        }

        protected virtual void ExitRoom()
        {
            Debug.Log($"{RoomName} ≈¿Â");
            uiManager.ExitRoom();
            return;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                EnterRoom();
            }
            else return;
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                ExitRoom();
            }
            else return;
        }
    }
}

