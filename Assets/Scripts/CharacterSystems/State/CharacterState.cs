using System;
using System.Collections.Generic;
using UnityEngine;
using Util.Enum;

namespace Jomjam
{
    public class CharacterState : MonoBehaviour
    {
        [SerializeField] protected SpriteRenderer m_character;
        [SerializeField] protected List<Sprite> m_emotion;
        protected CharState _state;
        private Animator _animator;
        protected GameManager GM;
        private GameStateManager GSM;

        private void Awake()
        {
            GSM = GameStateManager.Instance;
            GSM.OnGameStateChange += OnGameStateChanged;
        }

        protected virtual void OnEnable()
        {
            
        }

        protected virtual void Start()
        {
            GM = GameManager.Instance;
            _animator = GetComponent<Animator>();
            _state = CharState.Normal;
            
            if (m_emotion != null && m_emotion.Count > 0)
                m_character.sprite = m_emotion[0];
        }

        protected virtual void Update()
        {
            if(_animator == null)
                return;
            
            _animator.SetInteger("State", _state.GetHashCode());
        }

        private void OnGameStateChanged(GameState gameState)
        {
            enabled = gameState == GameState.Play;
        }
        
        public virtual void OnChangeHappyValue(float value, List<float> points)
        {
            if (value <= points[0])
                _state = CharState.Normal;
            else if (value <= points[1])
                _state = CharState.Happy;
            else if (value <= points[2])
                _state = CharState.Stressed;
            
            print($"{_state} is change state");
        }

        private void OnDestroy()
        {
            GSM.OnGameStateChange -= OnGameStateChanged;
        }
    }
}