using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Metaverse
{
    public class BaseNPC : BaseInteractive
    {
        [SerializeField] private GameObject messagePivot;
        public GameObject MessagePivot { get => messagePivot; set => messagePivot = value; }

        protected TextMeshProUGUI message;

        [SerializeField] protected string npcMessage;
        public string NpcMessage { get => npcMessage; }

        protected virtual void Start()
        {
            if (MessagePivot == null)
            {
                Debug.LogError($"{Name}'s Message Pivot is Null");
            }
            message = MessagePivot.GetComponentInChildren<TextMeshProUGUI>();
            message.text = NpcMessage;
            MessagePivot.SetActive(false);
            return;
        }

        public override void Interact()
        {
            base.Interact();
            ShowMessage();
        }

        public void ShowMessage()
        {
            CancelInvoke();
            Debug.Log($"{Name} NPC�� ��ȣ�ۿ�");
            MessagePivot.SetActive(true);
            Invoke("EndMessage", 2f);
            return;
        }

        public void EndMessage()
        {
            MessagePivot.SetActive(false);
            return;
        }
    }
}

