using System;
using UnityEngine;
using UnityEngine.Events;
using Util.Enum;

namespace Jomjam
{
    public class HumanWorkingSystem : MonoBehaviour
    {
        [SerializeField] private float m_speedOffset = 0.5f;
        [SerializeField] private UnityEvent OnWorkDone;
        private GameManager GM;
        private GameStateManager GSM;
        private bool isDone;

        private void Awake()
        {
            GSM = GameStateManager.Instance;
            GSM.OnGameStateChange += OnGameStateChanged;
        }
        
        private void OnGameStateChanged(GameState gameState)
        {
            enabled = gameState == GameState.Play;
        }

        private void Start()
        {
            GM = GameManager.Instance;
        }

        private void Update()
        {
            OnWorking();
        }

        private void OnWorking()
        {
            if (GM.isSwitchScreen || GM.gameState == GameState.Pause)
                return;
            
            float work = 0;

            if (GM.humanState != CharState.Happy)
                work = GM.workProgrss + Time.deltaTime * (GM.workSpeed * Mathf.Abs((GM.humanSpeed[GM.humanState.GetHashCode()] - GM.humanSpeed[0]) / 10 * m_speedOffset - 1));
            else
            {
                work = GM.workProgrss + Time.deltaTime * (GM.workSpeed * Mathf.Abs(GM.humanSpeed[GM.humanState.GetHashCode()] / 10 * (m_speedOffset * 0.75f) - 1));
                
                //print($"fyytdtydc = {work}");
            }

            if (work < 100)
                GM.workProgrss = work;
            else if (work >= 100 && !isDone)
            {
                GM.workProgrss = 100;
                GM.gameState = GameState.Pause;
                GameStateManager.Instance.Setstate(GameState.Pause);
                OnWorkDone?.Invoke();
            }
        }
        
        private void OnDestroy()
        {
            GSM.OnGameStateChange -= OnGameStateChanged;
        }
    }
}