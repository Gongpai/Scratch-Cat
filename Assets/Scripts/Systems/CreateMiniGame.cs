using Jomjam;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

namespace Systems
{
    public class CreateMiniGame : MonoBehaviour
    {
        [SerializeField] private UnityEvent AddWinEvent;
        [SerializeField] private UnityEvent AddLoseEvent;
        [SerializeField] private GameObject m_miniGame;
        private GameObject spawnMiniGame;

        public void OnCreateMiniGame()
        {
            spawnMiniGame = Instantiate(m_miniGame, transform);
            spawnMiniGame.GetComponent<MiniGameElements>().gameObject[0].GetComponent<TaoSystem>().AddOnDek = AddWinEvent;
            spawnMiniGame.GetComponent<MiniGameElements>().gameObject[1].GetComponent<KokowaSystem>().OnCatSee = AddLoseEvent;
        }

        public void OnClearMiniGame()
        {
            Destroy(spawnMiniGame);
        }
    }
}