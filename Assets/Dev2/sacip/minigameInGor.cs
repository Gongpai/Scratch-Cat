using System.Collections;
using System.Collections.Generic;
using GDD.Timer;
using Jomjam;
using UnityEngine;
using Util.Enum;
using AudioSource = UnityEngine.AudioSource;

namespace Assets.Dev2.sacip
{
    public class minigameInGor : MonoBehaviour
    {
        public float timeCount = 2.0f;
        public GameObject minigamesign;

        public float minspeed;
        public float maxspeed;
        public float currentspeed;

        [SerializeField]
        private List<miniSignpoint> m_minielement = new List<miniSignpoint>();
        private GameManager GM;
        private AwaitTimer _timer;

        private void Start()
        {
            GM = GameManager.Instance;
            currentspeed = minspeed;
            OnStartTimer();
            
            Spawn();
        }

        private void OnStartTimer()
        {
            _timer = new AwaitTimer(timeCount, OnEndTime, currentTime =>
            {
                //print($"Current Time = {currentTime}");
            });
            
            _timer.Start();
        }

        private void OnEndTime()
        {
            Spawn();
            OnStartTimer();
        }

        public void Spawn()
        {
            if(GM.isSwitchScreen || GM.gameState == GameState.Pause)
                return;
            
            GameObject sign = Instantiate(minigamesign, transform.position, transform.rotation);
            sign.transform.parent = transform.parent;
            sign.GetComponent<miniSignpoint>().signspawn = this;
            sign.GetComponent<miniSignpoint>().OnDestroyObject = () =>
            {
                GameObject destroyGObject = m_minielement[0].gameObject;
                m_minielement.RemoveAt(0);
                Destroy(destroyGObject);
            };
            m_minielement.Add(sign.GetComponent<miniSignpoint>());
        }
        
        private void Update()
        {
            if (GM.isSwitchScreen || GM.gameState == GameState.Pause)
            {
                _timer.Pause();
                return;
            }
            else
            {
                _timer.Resume();
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                if(m_minielement.Count <= 0)
                    return;
                
                m_minielement[0].OnEnter();
                GameObject destroyGObject = m_minielement[0].gameObject;
                m_minielement.RemoveAt(0);
                Destroy(destroyGObject);
            }
        }
    }
}
