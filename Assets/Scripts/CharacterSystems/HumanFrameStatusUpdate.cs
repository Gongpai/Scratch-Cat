using System;
using UnityEngine;

namespace Jomjam
{
    public class HumanFrameStatusUpdate : CharacterState
    {
        protected override void Start()
        {
            base.Start();
            
            _state = GM.humanState;
        }

        protected override void Update()
        {
            _state = GM.humanState;
            base.Update();
        }
    }
}