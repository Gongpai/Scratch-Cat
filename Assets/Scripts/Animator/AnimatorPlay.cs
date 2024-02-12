using System;
using UnityEngine;

namespace Jomjam
{
    public class AnimatorPlay : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        private void Start()
        {
            _animator = GetComponent<Animator>();
        }

        public void PlayWithTrigger(string name)
        {
            _animator.SetTrigger(name);
        }

        public void PlayWithBool(string name)
        {
            _animator.SetBool(name, true);
        }
        
        public void ReverseWithBool(string name)
        {
            _animator.SetBool(name, false);
        }
        
        public void AutoPlayWithBool(string name)
        {
            _animator.SetBool(name, !_animator.GetBool(name));
        }
    }
}