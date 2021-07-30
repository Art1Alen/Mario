using UnityEngine;
using System;

namespace Platformer
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField] private Transform _player;
        private Vector3 _pos;
       

        private void Awake()
        {
            if (!_player)
                _player = FindObjectOfType<Hero>().transform;
        }
        private void Update()
        {
            _pos = _player.position;
            _pos.z = -10f;

            transform.position = Vector3.Lerp(transform.position, _pos, Time.deltaTime);
        }
    }
}
