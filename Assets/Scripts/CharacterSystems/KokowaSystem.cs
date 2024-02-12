using System;
using GDD.Timer;
using UnityEngine;
using UnityEngine.Events;
using Util.Enum;
using Random = UnityEngine.Random;

namespace Jomjam
{
    public class KokowaSystem : MonoBehaviour
    {
        [SerializeField] private Character2DController _character2DController;
        [SerializeField] private UnityEvent OnKadukhu;
        [SerializeField] private UnityEvent OnWakeUp;
        [SerializeField] private UnityEvent OnSleep;
        [SerializeField] private UnityEvent m_OnCatSee;
        [SerializeField] private float _randomMinTime;
        [SerializeField] private float _ramdomMaxTime;
        private Animator _animator;
        private float _currentTimeKadikhu;
        private float _currentTimeSleep;
        private float _currentTimeWakeUp;
        private AwaitTimer _timerKadikhu;
        private AwaitTimer _timerSleep;
        private AwaitTimer _timerWakeUp;
        private AwaitTimer _endTimer;
        private MiniGameCatState catState = MiniGameCatState.Sleep;
        private bool isGoBye;
        private GameStateManager GSM;

        private void Awake()
        {
            GSM = GameStateManager.Instance;
            GSM.OnGameStateChange += OnGameStateChanged;

            _endTimer = new AwaitTimer(1.25f, () =>
            {
                m_OnCatSee?.Invoke();
                _endTimer.Stop();
            }, time =>
            {

            });
        }
        
        private void OnGameStateChanged(GameState gameState)
        {
            enabled = gameState == GameState.Play;
        }

        public UnityEvent OnCatSee
        {
            get => m_OnCatSee;
            set => m_OnCatSee = value;
        }
        
        private void Start()
        {
            _animator = GetComponent<Animator>();
            NewSleepTimer();
            _timerSleep.Start();
        }

        private void Update()
        {
            DetectTao();
        }

        private void DetectTao()
        {
            if(_character2DController.rigidbody2D.velocity.magnitude > 0.01f && !isGoBye && catState == MiniGameCatState.Kadikhu)
            {
                _animator.SetTrigger("OnTuy");
                isGoBye = true;
                _endTimer.Start();
            }
        }
        
        private void NewKadikhuTimer()
        {
            _currentTimeKadikhu = Random.Range(_randomMinTime, _ramdomMaxTime);
            _timerKadikhu = new AwaitTimer(_currentTimeKadikhu, () =>
            {
                NewSleepTimer();
                _timerSleep.Start();
                OnSleep?.Invoke();
                _animator.SetTrigger("OnSleep");
                catState = MiniGameCatState.Sleep;
                
                NewKadikhuTimer();
            }, currentTime =>
            {
                
            });
        }

        private void NewWakeUpTime()
        {
            _currentTimeWakeUp = 3;
            _timerWakeUp = new AwaitTimer(_currentTimeWakeUp, () =>
            {
                NewKadikhuTimer();
                _timerKadikhu.Start();
                OnKadukhu?.Invoke();
                _animator.SetTrigger("OnSee");
                catState = MiniGameCatState.Kadikhu;
                
                NewWakeUpTime();
            }, currentTime =>
            {

            });
        }
        
        private void NewSleepTimer()
        {
            _currentTimeSleep = Random.Range(_randomMinTime, _ramdomMaxTime);
            _timerSleep = new AwaitTimer(_currentTimeSleep, () =>
            {
                NewWakeUpTime();
                _timerWakeUp.Start();
                OnWakeUp?.Invoke();
                _animator.SetTrigger("OnWekeUp");
                catState = MiniGameCatState.WakeUp;

                NewSleepTimer();
            }, currentTime =>
            {
                
            });
        }
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Tao"))
            {
                
            }
        }

        public void OnDestroyCharacter()
        {
            Destroy(gameObject);
        }
        
        private void OnDestroy()
        {
            GSM.OnGameStateChange -= OnGameStateChanged;
        }
    }
}