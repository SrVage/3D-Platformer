using Code.Abstraction;
using UnityEngine;

namespace Code.Hero
{
    public class HeroMove:MonoBehaviour
    {
        private IInputService _inputService;
        public Transform Raycast;
        public Rigidbody Rigidbody;
        public float MoveSpeed;
        public float RotationSpeed;

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.TryGetComponent<IInteract>(out IInteract interact))
                interact.Interact();
        }
    }
}