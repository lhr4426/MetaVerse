using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Metaverse
{
    public abstract class BaseInteractive : MonoBehaviour
    {
        [SerializeField] private string name;
        public string Name { get => name; set => name = value; }
        public virtual void Interact()
        {
            Debug.Log($"{Name} ��ȣ�ۿ� ����");
            return;
        }
    }
}

