using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;


namespace Movement
{
    

    public class Mover : MonoBehaviour
    {
        [Header("HirizontalMovement")]
        [SerializeField] private float _speed;
        [SerializeField] private bool _faceRight;
        [Header("Jamp")]
        [SerializeField] private float _jumpPower;
        [SerializeField] private Transform  _groundChecker;
        [SerializeField] private float _groundCheckRadius;
        [SerializeField] private LayerMask _whatIsGround;
        private Rigidbody2D _rigidbody2D;
        private float _direction;
        private bool _jump;
        private bool _isFacingUp;
        private bool _isJumping;


        private void Start()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            _direction = Input.GetAxisRaw("Horizontal");
            if (Input.GetButtonDown("Jump"))
                _jump = true;
        }

        private void FixedUpdate()
        {
            bool isGrounded = Physics2D.OverlapCircle(_groundChecker.position, _groundCheckRadius, _whatIsGround);
           
   
            if (!isGrounded)
            {
                _isJumping = true;
                if (_rigidbody2D.velocity.y > 0)
                    _isFacingUp = true;
                else
                    _isFacingUp = false;
            }
            else
            {
                _isJumping = false;
            }

            
    
        Move(_direction);
            SetDirection();
            if (_jump && isGrounded)
                Jump ();
            _jump = false;
        }
        
        private void Move(float direction)
        {
            _rigidbody2D.velocity = new Vector2(_speed * direction, _rigidbody2D.velocity.y);
        }
        private void Jump()
        {
            if (_isFacingUp)
            _rigidbody2D.AddForce(Vector2.up * _jumpPower);
            else
                _rigidbody2D.AddForce(Vector2.up * _jumpPower);
        }
        private void SetDirection()
        {
            if (_faceRight && _direction < 0)
                Flip();
            else if (!_faceRight && _direction > 0)
                Flip();
        }
        
         private void Flip()
            {
                _faceRight = !_faceRight;
                Vector3 scale = transform.localScale;
                scale.x *= -1;
                transform.localScale = scale;
            }

        

    } }