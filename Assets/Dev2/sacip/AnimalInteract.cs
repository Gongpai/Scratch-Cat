using System;
using System.Collections;
using System.Collections.Generic;
using Jomjam;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Dev2.sacip
{
    public class AnimalInteract : MonoBehaviour
    {
        public bool isNotAnimal;
        
        [SerializeField]
        private UnityEvent OnClick;

        [SerializeField] 
        private UnityEvent OnAnimalAngry;
        
        public Animator anim;
        private GameManager GM;

        private void Start()
        {
            GM = GameManager.Instance;
        }


        private void OnMouseDown()
        {
            
            if(isNotAnimal)
                return;
            
            anim.SetTrigger("idlee");
            OnClick?.Invoke();
            
            if(GM.catHappy >= GM.humanHappyPoints[2])
                OnAnimalAngry?.Invoke();
        }

    }
}
