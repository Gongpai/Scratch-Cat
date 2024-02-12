using System;
using Jomjam;
using UnityEngine;
using UnityEngine.Animations;

namespace Jomjam
{
    public class GameStateMachineBehaviours : StateMachineBehaviour
    {
        [SerializeField] private bool isWaitUntilEnd;
        [SerializeField] private bool isSwitch;
        private GameManager GM;

        private void OnEnable()
        {
            GM = GameManager.Instance;
        }

        public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            base.OnStateUpdate(animator, stateInfo, layerIndex);
            
            //Debug.Log($"Current Time {stateInfo.normalizedTime} || {stateInfo.length}");
            if (isWaitUntilEnd)
            {
                if (stateInfo.normalizedTime >= stateInfo.length)
                    GM.isSwitchScreen = isSwitch;
            }
            else
            {
                GM.isSwitchScreen = isSwitch;
            }
        }
    }
}