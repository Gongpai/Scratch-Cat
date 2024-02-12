using System;
using UnityEngine;
using Util.Enum;

namespace Jomjam
{
    public class CharacterEmotionSystem : MonoBehaviour
    {
        [SerializeField] protected float m_speedInsEmotion;
        [SerializeField] protected float m_buttonPosY = 20;
        protected GameManager GM;
        private GameStateManager GSM;

        private void Awake()
        {
            GSM = GameStateManager.Instance;
            GSM.OnGameStateChange += OnGameStateChanged;
        }

        protected virtual void Start()
        {
            GM = GameManager.Instance;
        }

        protected virtual void Update()
        {
            OnChangeEmotion();
        }

        private void OnGameStateChanged(GameState gameState)
        {
            enabled = gameState == GameState.Play;
        }
        
        /*
        private void OnGUI()
        {
            if(GUI.Button(new Rect(20,m_buttonPosY,150, 50), "Add Emotion"))
                OnAddEmotion();
        }*/

        public virtual void OnAddEmotion()
        {
            
        }

        protected virtual void OnChangeEmotion()
        {
            
        }

        private void OnDestroy()
        {
            GSM.OnGameStateChange -= OnGameStateChanged;
        }
    }
}