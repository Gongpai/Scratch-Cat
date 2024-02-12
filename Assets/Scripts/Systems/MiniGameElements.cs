using System.Collections.Generic;
using UnityEngine;

namespace Systems
{
    public class MiniGameElements : MonoBehaviour
    {
        [SerializeField]
        private List<GameObject> m_gameObject = new List<GameObject>();

        public List<GameObject> gameObject
        {
            get => m_gameObject;
        }
    }
}