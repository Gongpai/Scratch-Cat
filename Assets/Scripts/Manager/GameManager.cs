using System.Collections;
using System.Collections.Generic;
using GDD.Sinagleton;
using UnityEngine;
using UnityEngine.Serialization;
using Util.Enum;
using Util.Struct;

namespace Jomjam
{
    public class GameManager : CanDestroy_Sinagleton<GameManager>
    {
        [Header("Cat")] 
        [SerializeField][Range(0, 100)] private float m_catHappy;
        [SerializeField] private List<float> m_catHappyPoints;
        [SerializeField] private List<Color> m_catHappyPointColors;
        [SerializeField] private List<float> m_catSpeed;
        private CharState _catState;
        
        [Header("Human")] 
        [SerializeField][Range(0, 100)] private float m_humanHappy;
        [SerializeField] private List<float> m_humanHappyPoints;
        [SerializeField] private List<Color> m_humanHappyPointColors;
        [SerializeField] private List<float> m_humanSpeed;
        [SerializeField] private int _playAgainCount;
        private CharState _humanState;

        [Header("Work Progress")] 
        [SerializeField][Range(0, 100)] private float m_workProgrss;
        [SerializeField] private float m_workSpeed;
        
        //Switch State
        private bool _isSwitchScreen;

        private GameState _gameState;

        public float catHappy
        {
            get => m_catHappy;
            set => m_catHappy = value;
        }

        public float humanHappy
        {
            get => m_humanHappy;
            set => m_humanHappy = value;
        }

        public CharState catState
        {
            get => _catState;
            set => _catState = value;
        }
        
        public CharState humanState
        {
            get => _humanState;
            set => _humanState = value;
        }

        public int playAgainCount
        {
            get => _playAgainCount;
            set => _playAgainCount = value;
        }

        public List<float> catHappyPoints
        {
            get => m_catHappyPoints;
        }

        public List<Color> catHappyPointColors
        {
            get => m_catHappyPointColors;
        }
        
        public List<float> humanHappyPoints
        {
            get => m_humanHappyPoints;
        }
        
        public List<Color> humanHappyPointColors
        {
            get => m_humanHappyPointColors;
        }

        public float workProgrss
        {
            get => m_workProgrss;
            set => m_workProgrss = value;
        }

        public float workSpeed
        {
            get => m_workSpeed;
        }

        public List<float> catSpeed
        {
            get => m_catSpeed;
        }

        public List<float> humanSpeed
        {
            get => m_humanSpeed;
        }

        public bool isSwitchScreen
        {
            get => _isSwitchScreen;
            set => _isSwitchScreen = value;
        }

        public GameState gameState
        {
            get => _gameState;
            set => _gameState = value;
        }
        
        // Start is called before the first frame update
        void Start()
        {
            _gameState = GameState.Play;
        }

        // Update is called once per frame
        void Update()
        {
            switch (_gameState)
            {
                case GameState.Play:
                    break;
                case GameState.End:
                    print("Game Over");
                    break;
            }
        }

        public void PauseGame()
        {
            gameState = GameState.Pause;
            GameStateManager.Instance.Setstate(GameState.Pause);
        }

        public void ResumeGame()
        {
            gameState = GameState.Play;
            GameStateManager.Instance.Setstate(GameState.Play); 
        }
        
        public void UnPauseGame()
        {
            gameState = GameState.Play;
        }

        public void ResetHumanEmotionCenterPoint()
        {
            humanHappy = humanHappyPoints[0];
        }
        
        public void ResetHumanWorkHaftPoint()
        {
            workProgrss = workProgrss * 0.5f;
        }
    }
}