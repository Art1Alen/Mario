﻿//using UnityEngine;
//using System.Collections.Generic;


//namespace PlatformerMVC
//{
//    public class BulletsEmitterController
//    {
//        private List<BulletController> _bullets = new List<BulletController>();
//        private Transform _transform;

//        private int _currentIndex;
//        private float _timeTillNextBullet;

//        private const float _delay = 1;
//        private const float _startSpeed = 9;

//        public BulletsEmitterController(List<CannonView> bulletViews, Transform transform)
//        {
//            _transform = transform;
//            foreach (var BulletView in bulletViews)
//            {
//                _bullets.Add(new BulletController(bulletViews));
//            }
//        }

//        public void Update()
//        {
//            if (_timeTillNextBullet > 0)
//            {
//                _bullets[_currentIndex].Active(false);
//                _timeTillNextBullet -= Time.deltaTime;
//            }
//            else
//            {
//                _timeTillNextBullet = _delay;

//                _bullets[_currentIndex].Throw(_transform.position, _transform.up * _startSpeed);
//                _currentIndex++;

//                if (_currentIndex >= _bullets.Count)
//                {
//                    _currentIndex = 0;
//                }
//            }

//        }



//    }
//}
