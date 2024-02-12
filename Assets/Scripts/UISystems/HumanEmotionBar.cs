using UnityEngine;

namespace Jomjam
{
    public class HumanEmotionBar : EmotionBar
    {
        protected override void Start()
        {
            base.Start();
            
            _thisRectSize = GetComponent<RectTransform>().sizeDelta;
            AutoYSeparateProgressBar(GM.humanHappyPoints, GM.humanHappyPointColors);
        }

        protected override void Update()
        {
            value = GM.humanHappy;
            
            base.Update();
        }
    }
}