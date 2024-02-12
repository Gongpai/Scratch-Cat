using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Util.Enum;

namespace Jomjam
{
    public class GameStateManager
    {

        private static GameStateManager _instance;

        public static GameStateManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new GameStateManager();
                }

                return _instance;
            }
        }

        public GameState currentGameState { get; private set; }

        public delegate void GameStateChangeHandler(GameState gamestate);

        public event GameStateChangeHandler OnGameStateChange;

        private GameStateManager()
        {

        }

        public void Setstate(GameState gamestate)
        {
            if (gamestate == currentGameState)
                return;

            currentGameState = gamestate;
            OnGameStateChange?.Invoke(gamestate);
        }

        public static void Reset_Game_State()
        {
            _instance = null;
        }
    }
}