using UnityEngine;

namespace Jomjam
{
    public class CatEmotionSystem : CharacterEmotionSystem
    {
        protected override void Start()
        {
            base.Start();
        }

        public override void OnAddEmotion()
        {
            base.OnAddEmotion();

            float happy = GM.catHappy + GM.catSpeed[GM.catState.GetHashCode()];
            
            if(happy < 100)
                GM.catHappy = happy;
            else if (happy >= 100)
                GM.catHappy = 100;
        }

        protected override void OnChangeEmotion()
        {
            base.OnChangeEmotion();
            
            if (GM.catHappy > 0)
                GM.catHappy -= Time.deltaTime * m_speedInsEmotion;
            else if (GM.catHappy <= 0)
                GM.catHappy = 0;
        }
    }
}