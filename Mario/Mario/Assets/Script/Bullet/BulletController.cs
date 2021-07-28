using System.Collections.Generic;
using UnityEngine;

namespace PlatformerMVC
{
    public class BulletController
    {
        private Vector3 _velocity;
        private LevelObjectView _view;
        private List<LevelObjectView> bulletViews;

        private List<LevelObjectView> _bulletViews;

        public BulletController(LevelObjectView view)
        {
            _view = view;
            //Active(false);
        }


        public BulletController(List<LevelObjectView> bulletViews)
        {
            this.bulletViews = bulletViews;
        }

        private void SetVelocity(Vector3 velocity)
        {
            _velocity = velocity;
            var angle = Vector3.Angle(Vector3.left, _velocity);
            var axis = Vector3.Cross(Vector3.left, _velocity);
            _view.transform.rotation = Quaternion.AngleAxis(angle, axis);

        }
        public void Throw(Vector3 position, Vector3 velocity)
        {
            //Active(true);
            SetVelocity(velocity);
            _view.transform.position = position;
            _view.Rigidbody2D.velocity = Vector2.zero;
            _view.Rigidbody2D.angularVelocity = 0;
            _view.Rigidbody2D.AddForce(velocity, ForceMode2D.Impulse);
            //Active(true);
        }
        //public void Active(bool val)
        //{
        //    _view._trail.enabled = val;
        //    _view.gameObject.SetActive(val);
        //}

    }

}
