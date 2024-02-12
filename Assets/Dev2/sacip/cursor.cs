using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Assets.Dev2.sacip
{
    public class cursor : MonoBehaviour
    {
        private Image rended;
        public Sprite Normal;
        public Sprite Click;
        private RectTransform _rectTransform;

        // Start is called before the first frame update
        void Start()
        {
            Cursor.visible = false;
            rended = GetComponent<Image>();
            _rectTransform = GetComponent<RectTransform>();
        }
        void Update()
        {
            _rectTransform.anchoredPosition = Input.mousePosition - new Vector3(81.201171875f, 53.2861328125f, 0);

            if (Input.GetMouseButtonDown(0))
            {
                rended.sprite = Click;
            }
            
            if(Input.GetMouseButtonUp(0))
            {
                rended.sprite = Normal;
            }
        }
    }
}
