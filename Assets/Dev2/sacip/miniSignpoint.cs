using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Jomjam;
using UnityEngine.Events;
using Util.Enum;

namespace Assets.Dev2.sacip
{
    public class miniSignpoint : MonoBehaviour
    {
        
        public AudioClip _cuuuuSound;
        public AudioClip _wwwwwSound;
        public minigameInGor signspawn;
        private GameManager GM;
        public bool isEnter;
        public UnityAction OnDestroyObject;
        
        private AudioSource _audioSource;

        private void Start()
        {
            _audioSource = GetComponent<AudioSource>();
            GM = GameManager.Instance;
        }

        private void Update()
        {
            if(GM.isSwitchScreen || GM.gameState == GameState.Pause)
                return;
            
            transform.Translate(Vector2.left * signspawn.currentspeed * Time.deltaTime);
        }

        public void OnEnter()
        {
            if(GM.isSwitchScreen)
                return;

            if (isEnter)
            {
                GM.workProgrss += 1;
                _audioSource.clip = _cuuuuSound;
                _audioSource.Play();
            }
            else
            {
                GM.workProgrss -= 1;
                _audioSource.clip = _wwwwwSound;
                _audioSource.Play();
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("minigameline"))
            {
                Destroy(this.gameObject);
                OnEnter();
                OnDestroyObject?.Invoke();
            }
            
            if(collision.gameObject.CompareTag("minigamePlayer"))
                isEnter = true;
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if(collision.gameObject.CompareTag("minigamePlayer"))
                isEnter = false;
        }
    }
}
