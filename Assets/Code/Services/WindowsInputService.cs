using Code.Abstraction;
using UnityEngine;

namespace Code.Services
{
    public class WindowsInputService:IInputService
    {
        private const string Horizontal = "Horizontal";
        private const string Vertical = "Vertical";
        private const string ButtonJump = "Jump";
        public Vector2 Axis
        {
            get
            {
                Vector2 axis;
                axis = new Vector2(SimpleInput.GetAxis(Horizontal), SimpleInput.GetAxis(Vertical));
                if (axis == Vector2.zero)
                {
                    axis = new Vector2(Input.GetAxis(Horizontal), Input.GetAxis(Vertical));
                }

                return axis;
            }
        }

        public bool Jump
        {
            get
            {
                bool jump;
                jump = SimpleInput.GetButton(ButtonJump);
                if (jump == false)
                    jump = Input.GetKeyDown(KeyCode.Space);
                return jump;
            }
        }
    }
}