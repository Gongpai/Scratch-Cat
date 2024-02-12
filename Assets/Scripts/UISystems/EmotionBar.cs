using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Util.Struct;
using Random = UnityEngine.Random;

namespace Jomjam
{
    public class EmotionBar : MonoBehaviour
    {
        [SerializeField] private Slider m_slider;
        [SerializeField][Range(0, 100)] private float m_value = 0.0f;
        [SerializeField] private GameObject m_parentBGProgressBar;
        [SerializeField] private GameObject m_BGProgress;
        [SerializeField] float m_topOffset;
        protected List<RectTransform> _bgProgress = new List<RectTransform>();
        protected GameManager GM;
        protected Vector2 _thisRectSize;
        
        public float value
        {
            get => m_value;
            set => m_value = value;
        }

        protected virtual void Start()
        {
            GM = GameManager.Instance;
        }

        protected virtual void Update()
        {
            m_slider.value = m_value;
        }

        protected virtual void AutoXSeparateProgressBar(List<float> values, List<Color> colors = null)
        {
            float oldPosX = 0;
            for (int i = 0; i < values.Count; i++)
            {
                RectTransform rectBar = Instantiate(m_BGProgress).GetComponent<RectTransform>();
                rectBar.SetParent(m_parentBGProgressBar.transform);
                rectBar.transform.localPosition = Vector3.zero;
                rectBar.anchoredPosition = new Vector2(oldPosX, rectBar.anchoredPosition.y);
                rectBar.anchorMin = Vector2.zero;
                rectBar.anchorMax = new Vector2(0, 1);
                rectBar.sizeDelta = new Vector2(_thisRectSize.x * (values[i] / 100) - oldPosX, 0);
                rectBar.localScale = Vector3.one;
                oldPosX += rectBar.sizeDelta.x;

                if (colors == null)
                    rectBar.GetComponent<Image>().color = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f),
                        Random.Range(0.0f, 1.0f), 1);
                else
                    rectBar.GetComponent<Image>().color = colors[i];
            }
        }
        
        protected virtual void AutoYSeparateProgressBar(List<float> values, List<Color> colors = null)
        {
            float oldPosY = 0;
            for (int i = 0; i < values.Count; i++)
            {
                RectTransform rectBar = Instantiate(m_BGProgress).GetComponent<RectTransform>();
                rectBar.SetParent(m_parentBGProgressBar.transform);
                rectBar.transform.localPosition = Vector3.zero;
                rectBar.pivot = Vector2.zero;
                rectBar.anchoredPosition = new Vector2(0, oldPosY);
                rectBar.anchorMin = Vector2.zero;
                rectBar.anchorMax = new Vector2(1, 0);
                rectBar.sizeDelta = new Vector2(0, (_thisRectSize.y - m_topOffset) * (values[i] / 100) - oldPosY);
                rectBar.localScale = Vector3.one;
                oldPosY += rectBar.sizeDelta.y;

                if (colors == null)
                    rectBar.GetComponent<Image>().color = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f),
                        Random.Range(0.0f, 1.0f), 1);
                else
                    rectBar.GetComponent<Image>().color = colors[i];
            }
        }
    }
}