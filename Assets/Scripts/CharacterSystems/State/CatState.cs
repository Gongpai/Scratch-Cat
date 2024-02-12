using System.Collections.Generic;

namespace Jomjam
{
    public class CatState : CharacterState
    {
        protected override void Start()
        {
            base.Start();
            _state = GM.catState;
        }

        protected override void Update()
        {
            _state = GM.catState;
            OnChangeHappyValue(GM.catHappy, GM.catHappyPoints);
            
            base.Update();

            GM.catState = _state;
        }

        public override void OnChangeHappyValue(float value, List<float> points)
        {
            base.OnChangeHappyValue(value, points);
        }
    }
}