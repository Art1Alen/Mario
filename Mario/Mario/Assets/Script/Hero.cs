using UnityEngine;
using System;

namespace Platformer
{
    public class Hero : MonoBehaviour
    {
        [SerializeField] private float _speed = 3f; //Скорость передвижение
        [SerializeField] private int _lives = 5; // количество жизни
        [SerializeField] private float _jumpForce = 15f;// сила прыжка
        private bool _isGrounded = false;
       
        private Rigidbody2D _rigidbody2;
        private SpriteRenderer _spriteRenderer;
       
        private void Awake()
        {
            _rigidbody2 = GetComponent<Rigidbody2D>();
            _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        }
        private void FixedUpdate()
        {
            CheckGround();
        }

        private void Update()
        {
            if (Input.GetButton("Horizontal"))
                Run();
            if (_isGrounded && Input.GetButtonDown("Jump"))
                Jump();
        }

        private void Run() // Метод ходьбы
        {
            Vector3 dir = transform.right * Input.GetAxis("Horizontal");
            transform.position = Vector3.MoveTowards(transform.position, transform.position + dir, _speed * Time.deltaTime);

            _spriteRenderer.flipX = dir.x < 0.0f;
        }

        private void Jump() // Метод прышка
        {
            _rigidbody2.AddForce(transform.up * _jumpForce, ForceMode2D.Impulse);
        }

        private void CheckGround() // Проверка под ногами для прышка
        {
            Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 1f);
            _isGrounded = colliders.Length > 1;
        }
    }
}