using Code.Abstraction;
using UnityEngine;

namespace Code.Services
{
    public class AndroidInputService:IInputService
    {
        private const string Horizontal = "Horizontal";
        private const string Vertical = "Vertical";
        private const string ButtonJump = "Jump";
        public Vector2 Axis => new Vector2(SimpleInput.GetAxis(Horizontal), SimpleInput.GetAxis(Vertical));
        public bool Jump => SimpleInput.GetButton(ButtonJump);
    }
}