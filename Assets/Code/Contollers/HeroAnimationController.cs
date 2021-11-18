using System;
using Code.Abstraction.Controllers;
using Code.Hero;
using UnityEngine;

namespace Code.Contollers
{
    public class HeroAnimationController:IExecute
    {
        public event Action<IController> Dispose;
        private readonly int IsWalking = Animator.StringToHash("IsWalking");
        private readonly int Jump = Animator.StringToHash("Jump");
        private readonly int Speed = Animator.StringToHash("Speed");
        private HeroAnimation _heroAnimation;
        private HeroMoveController _moveController;

        public HeroAnimationController(HeroAnimation heroAnimation, HeroMoveController moveController)
        {
            _heroAnimation = heroAnimation;
            _moveController = moveController;
            _moveController.Jump += DoJump;
        }

        public void Execute(float deltaTime)
        {
            if (_moveController.Walk)
            {
                _heroAnimation.Animator.SetBool(IsWalking, true);
                _heroAnimation.Animator.SetFloat(Speed, _moveController.CurrentSpeed);
            }
            else
            {
                _heroAnimation.Animator.SetBool(IsWalking, false);
            }
        }

        private void DoJump()
        {
            _heroAnimation.Animator.SetTrigger(Jump);
        }

        public void Disposed()
        {
            Dispose?.Invoke(this);
        }
    }
}