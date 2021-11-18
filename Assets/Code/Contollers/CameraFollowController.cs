using System;
using Code.Abstraction.Controllers;
using UnityEngine;

namespace Code.Contollers
{
    public class CameraFollowController:ILateExecute
    {
        public event Action<IController> Dispose;
        private Transform _follow;
        private Transform _camera;
        

        public CameraFollowController(Transform follow, Transform camera)
        {
            _follow = follow;
            _camera = camera;
        }

        public void LateExecute(float deltaTime)
        {
            if (_follow==null) return;
            _camera.position = _follow.position;
            _camera.rotation = _follow.rotation;
        }

        public void Disposed()
        {
            Dispose?.Invoke(this);
        }
    }
}