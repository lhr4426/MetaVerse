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
            // ���߿� ��ӹ޾Ƽ� override �� �޽��� ���� �����ϸ� ��
            return;
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

