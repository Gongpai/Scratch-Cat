using System;
using GDD.Timer;
using UnityEngine;
using UnityEngine.Events;
using Util.Enum;

namespace Jomjam
{
    public class TaoSystem : MonoBehaviour
    {
        [SerializeField] private KokowaSystem _kokowaSystem;
        [SerializeField] private UnityEvent OnDek;
        private Animator _animator;
        private Character2DController _character2DController;
        private GameStateManager GSM;
        private AwaitTimer _timer;

        private void Awake()
        {
            GSM = GameStateManager.Instance;
            GSM.OnGameStateChange += OnGameStateChanged;

            _timer = new AwaitTimer(1.25f, () =>
                {
                    OnDek?.Invoke();
                    _timer.Stop();
                },
                time =>
                {

                });
        }
        
        private void OnGameStateChanged(GameState gameState)
        {
            enabled = gameState == GameState.Play;
        }
        
        private void OnDestroy()
        {
            GSM.OnGameStateChange -= OnGameStateChanged;
        }
        
        public UnityEvent AddOnDek
        {
            get => OnDek;
            set => OnDek = value;
        }

        private void Start()
        {
            _character2DController = GetComponent<Character2DController>();
            _animator = GetComponent<Animator>();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Cat")) ;
            {
                _timer.Start();
                _character2DController.enabled = false;
                _animator.SetTrigger("OnDek");
            }
        }

        public void DestroyCharacter()
        {
            _kokowaSystem.GetComponent<Animator>().SetTrigger("OnDek");
        }
    }
}