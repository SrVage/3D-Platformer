using System.Collections.Generic;
using Code.Abstraction.Controllers;

namespace Code.Contollers
{
    public class Controllers
    {
        private List<IInit> _inits = new List<IInit>();
        private List<IExecute> _executes = new List<IExecute>();
        private List<ILateExecute> _lateExecutes = new List<ILateExecute>();
        private List<IFixedExecute> _fixedExecutes = new List<IFixedExecute>();

        public Controllers()
        {
        }

        public void AddController(IController controller)
        {
            controller.Dispose += DeleteController;
            if (controller is IInit init) 
                _inits.Add(init);
            if (controller is IExecute execute)
                _executes.Add(execute);
            if (controller is ILateExecute lateExecute)
                _lateExecutes.Add(lateExecute);
            if (controller is IFixedExecute fixedExecute)
                _fixedExecutes.Add(fixedExecute);
        }

        private void DeleteController(IController controller)
        {
            controller.Dispose -= DeleteController;
            if (controller is IInit init) 
                _inits.Remove(init);
            if (controller is IExecute execute)
                _executes.Remove(execute);
            if (controller is ILateExecute lateExecute)
                _lateExecutes.Remove(lateExecute);
            if (controller is IFixedExecute fixedExecute)
                _fixedExecutes.Remove(fixedExecute);
            controller = null;
        }

        public void Init()
        {
            foreach (var init in _inits)
            {
                init.Init();
            }
        }

        public void Execute(float deltaTime)
        {
            foreach (var execute in _executes)
            {
                execute.Execute(deltaTime);
            }
        }

        public void LateExecute(float deltaTime)
        {
            foreach (var lateExecute in _lateExecutes)
            {
                lateExecute.LateExecute(deltaTime);
            }
        }

        public void FixedExecute(float fixedDeltaTime)
        {
            foreach (var fixedExecute in _fixedExecutes)
            {
                fixedExecute.FixedExecute(fixedDeltaTime);
            }
        }
    }
}