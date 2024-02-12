using System;
using UnityEngine;
using UnityEngine.UI;

namespace Jomjam
{
    public class WorkProgressBar : MonoBehaviour
    {
        [SerializeField] private Image m_imageFill;
        private GameManager GM;
        
        private void Start()
        {
            m_imageFill = GetComponent<Image>();
            GM = GameManager.Instance;
        }

        private void Update()
        {
            m_imageFill.fillAmount = GM.workProgrss / 100.0f;
        }
    }
}