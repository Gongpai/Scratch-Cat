using UnityEngine;
using UnityEngine.Events;

namespace Jomjam
{
    public class InvokeAnimationEvent : MonoBehaviour
    {
        [SerializeField] private UnityEvent AddEvent;
        
        public void Invoke()
        {
            AddEvent?.Invoke();
        }
    }
}