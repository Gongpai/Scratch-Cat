using UnityEngine;

namespace Jomjam
{
    public class CatEmotionBar : EmotionBar
    {
        protected override void Start()
        {
            base.Start();
            
            _thisRectSize = GetComponent<RectTransform>().sizeDelta;
            AutoYSeparateProgressBar(GM.catHappyPoints, GM.catHappyPointColors);
        }

        protected override void Update()
        {
            value = GM.catHappy;
            
            base.Update();
        }
    }
}