using System;
using RepeatUtil.DesignPattern.SingletonPattern;
using UnityEngine;

namespace Moduler.Player
{
    public class PlayerController : Singleton<PlayerController>
    {
        [SerializeField] private PlayerMovement playerMovement;
        
        protected override void RemoveDuplicates()
        {
            if(instance != null) { Destroy(gameObject); return; }
            instance = this;
        }

        protected override void LoadComponents()
        {
            base.LoadComponents();
            Action action = () =>
            {
                this.playerMovement = GetComponent<PlayerMovement>();
            };
            action();
        }
    }
}