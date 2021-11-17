using System;
using UnityEngine;

namespace Code.Services
{
    public class CameraFollowing:MonoBehaviour
    {
        private Transform _follow;
        public void Init(Transform follow)
        {
            _follow = follow;
        }

        private void LateUpdate()
        {
            if (_follow==null) return;
            transform.position = _follow.position;
            transform.rotation = _follow.rotation;
        }
    }
}