using System;
using Code.Abstraction;
using Code.Abstraction.Controllers;
using Code.Hero;
using UnityEngine;

namespace Code.Contollers
{
    public class HeroMoveController:IFixedExecute
    {
        public event Action<IController> Dispose;
        public event Action Jump;
        private const int JumpFactor = 10;
        public bool Walk { get; private set; }
        public float CurrentSpeed { get; private set; }
        private IInputService _inputService;
        private HeroMove _view;
        private Rigidbody _rigidbody;
        private Transform _transform;
        private Transform _raycast;
        private float _moveSpeed;
        private float _rotationSpeed;

        public void Init(IInputService inputService, HeroMove view)
        {
            _inputService = inputService;
            _view = view;
            _rigidbody = _view.Rigidbody;
            _transform = _view.transform;
            _raycast = view.Raycast;
            _moveSpeed = view.MoveSpeed;
            _rotationSpeed = view.RotationSpeed;
        }

        public void FixedExecute(float deltaTime)
        {
            if (_inputService == null)
            {
                return;
            }
            
            float movementVector = _inputService.Axis.normalized.y;
            if (Mathf.Abs(movementVector) > 0.1f)
            {
                Walk = true;
                CurrentSpeed = _rigidbody.velocity.magnitude;
                if (_rigidbody.velocity.magnitude < _moveSpeed)
                    _rigidbody.AddForce(movementVector * _transform.forward, ForceMode.VelocityChange);
            }
            else
            {
                Walk = false;
                _rigidbody.velocity = new Vector3(0, _rigidbody.velocity.y, 0);
            }

            _transform.Rotate(0, _inputService.Axis.normalized.x*_rotationSpeed, 0);
            if (_inputService.Jump)
            {
                //var hit = Physics.RaycastAll(_raycast.position, Vector3.down, 0.3f);
                var hit = Physics.OverlapBox(_raycast.position, Vector3.one/JumpFactor, Quaternion.identity);
                if (hit.Length>1)
                {
                    _rigidbody.AddForce(0, 10, 0, ForceMode.Impulse);
                    Jump?.Invoke();
                }
            }
        }

        public void Disposed()
        {
            GameObject.Destroy(_view.gameObject);
            Dispose?.Invoke(this);
        }
    }
}