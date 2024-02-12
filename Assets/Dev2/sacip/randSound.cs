using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Dev2.sacip
{
    public class randSound : MonoBehaviour
    {
        public AudioClip[] sounds;
        public AudioSource source;

        void Start()
        {
            source = GetComponent<AudioSource>();
        }

        void OnMouseDown()
        {
            source.clip = sounds[Random.Range(0, sounds.Length)];
            source.PlayOneShot(source.clip);
        }
    }
}
