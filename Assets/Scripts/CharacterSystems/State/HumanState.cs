using System.Collections.Generic;

namespace Jomjam
{
    public class HumanState : CharacterState
    {
        protected override void Start()
        {
            base.Start();
            
            _state = GM.humanState;
        }

        protected override void Update()
        {
            _state = GM.humanState;
            OnChangeHappyValue(GM.humanHappy, GM.humanHappyPoints);
            
            base.Update();
        }

        public override void OnChangeHappyValue(float value, List<float> points)
        {
            base.OnChangeHappyValue(value, points);
            
            GM.humanState = _state;
        }
    }
}