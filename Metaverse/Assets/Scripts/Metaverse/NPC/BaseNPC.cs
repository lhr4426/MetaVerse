using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Metaverse
{
    public class BaseNPC : MonoBehaviour
    {
        private string name;
        public string Name { get => name; set => name = value; }

        [SerializeField] private GameObject messagePivot;
        public GameObject MessagePivot { get => messagePivot; set => messagePivot = value; }

        protected TextMeshProUGUI message;

        protected virtual void Start()
        {
            if (MessagePivot == null)
            {
                Debug.LogError($"{Name}'s Message Pivot is Null");
            }
            message = MessagePivot.GetComponentInChildren<TextMeshProUGUI>();
            MessagePivot.SetActive(false);
            // 나중에 상속받아서 override 로 메시지 내용 지정하면 됨
            return;
        }

        public void ShowMessage()
        {
            CancelInvoke();
            Debug.Log($"{Name} NPC와 상호작용");
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

