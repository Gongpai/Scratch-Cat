using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

namespace Systems.Camera
{
    public class ChangeGlobalVolume : MonoBehaviour
    {
        [SerializeField] protected int _profileIndex;
        public Color m_color;
        public float value;

        protected Volume _volume;
        protected VolumeProfile _profile;
        protected VolumeComponent _volumeComponent;
        private Vignette _vignette;

        protected virtual void Start()
        {
            _volume = GetComponent<Volume>();
            _profile = _volume.profile;
            _volume.profile.TryGet<Vignette>(out _vignette);
        }

        protected virtual void Update()
        {
            _vignette.color.value = m_color;
            //Debug.Log($"Color {_vignette.color}");
        }
    }
}