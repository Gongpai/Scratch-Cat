using UnityEngine;
using UnityEngine.Events;
using Util.Enum;

namespace Jomjam
{
    public class HumanEmotionSystem : CharacterEmotionSystem
    {
        [SerializeField] private UnityEvent m_OnMaxEmotion;
        [SerializeField] private UnityEvent OnGameOver;
        
        protected override void Start()
        {
            base.Start();
        }

        public override void OnAddEmotion()
        {
            base.OnAddEmotion();
            
            float happy = GM.humanHappy - m_speedInsEmotion;
            
            if(GM.humanHappy > 0)
                GM.humanHappy = happy;
            else if (GM.humanHappy <= 0)
                GM.humanHappy = 0;
        }

        protected override void OnChangeEmotion()
        {
            if(GM.isSwitchScreen || GM.gameState == GameState.Pause)
                return;
            
            base.OnChangeEmotion();

            if (GM.humanHappy < 100)
            {
                GM.humanHappy += Time.deltaTime * GM.humanSpeed[GM.humanState.GetHashCode()];
            }
            else if (GM.humanHappy >= 100)
            {
                GM.humanHappy = 100;
                
                GM.gameState = GameState.Pause;
                if (GM.playAgainCount - 1 >= 0)
                {
                    GM.playAgainCount--;
                    m_OnMaxEmotion?.Invoke();
                }
                else
                {
                    OnGameOver?.Invoke();
                    GameStateManager.Instance.Setstate(GameState.Pause);
                }
            }
        }
    }
}