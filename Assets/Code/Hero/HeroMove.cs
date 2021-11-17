using Code.Abstraction;
using UnityEngine;

namespace Code.Hero
{
    public class HeroMove:MonoBehaviour
    {
        private IInputService _inputService;
        [SerializeField] private Transform _raycast;
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private float _moveSpeed;
        [SerializeField] private float _rotationSpeed;

        public void Init(IInputService inputService)
        {
            _inputService = inputService;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.TryGetComponent<IInteract>(out IInteract interact))
                interact.Interact();
        }

        private void Update()
        {
            if (_inputService == null) return;
            float movementVector =  _inputService.Axis.y;
            if (Mathf.Abs(movementVector) > 0.1f)
            {
                if (_rigidbody.velocity.magnitude < _moveSpeed)
                    _rigidbody.AddForce(movementVector * transform.forward, ForceMode.VelocityChange);
            }
            else
            {
                _rigidbody.velocity = new Vector3(0, _rigidbody.velocity.y, 0);
            }

            transform.Rotate(0, _inputService.Axis.x*_rotationSpeed, 0);
            if (_inputService.Jump)
            {
                var hit = Physics.RaycastAll(_raycast.position, Vector3.down, 0.3f);
                if (hit.Length>0)
                {
                    _rigidbody.AddForce(0, 5, 0, ForceMode.Impulse);
                }
            }
        }
    }
}