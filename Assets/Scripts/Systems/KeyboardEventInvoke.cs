using System;
using UnityEngine;
using UnityEngine.Events;
using Util.Enum;

namespace Jomjam
{
    public class KeyboardEventInvoke : MonoBehaviour
    {
        [SerializeField] private KeyCode m_key;
        [SerializeField] private UnityEvent m_OnPress;
        [SerializeField] private UnityEvent m_OnRelease;
        private GameStateManager GSM;
        
        private void Awake()
        {
            GSM = GameStateManager.Instance;
            GSM.OnGameStateChange += OnGameStateChanged;
        }
        
        private void OnGameStateChanged(GameState gameState)
        {
            enabled = gameState == GameState.Play;
        }
        
        private void OnDestroy()
        {
            GSM.OnGameStateChange -= OnGameStateChanged;
        }
        
        private void Update()
        {
            if(Input.GetKeyDown(m_key))
                m_OnPress?.Invoke();
            
            if(Input.GetKeyUp(m_key))
                m_OnRelease?.Invoke();
        }
    }
}