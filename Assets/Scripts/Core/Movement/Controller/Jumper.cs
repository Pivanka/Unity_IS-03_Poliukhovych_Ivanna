using Core.Movement.Data;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using StatsSystem;
using StatsSystem.Enum;

namespace Core.Movement.Controller
{
    public class Jumper
    {
        private readonly JumpData _jumpData;
        private readonly Rigidbody2D _rigidbody;
        private readonly Transform _transform;
        private readonly IStatValueGiver _statValueGiver;

        private float _startJumpVerticalPos;
        
        public bool IsJumping { get; private set; }

        public Jumper(Rigidbody2D rigidbody, JumpData jumpData, IStatValueGiver statValueGiver)
        {
            _rigidbody = rigidbody;
            _jumpData = jumpData;
            _transform = _rigidbody.transform;
            _statValueGiver = statValueGiver;
        }
        
        public void Jump()
        {
            if (IsJumping)
                return;

            IsJumping = true;
            
            _rigidbody.AddForce(Vector2.up * _statValueGiver.GetStatValue(StatType.JumpForce));
            _rigidbody.gravityScale = _jumpData.GravityScale;
            _startJumpVerticalPos = _transform.position.y;
        }

        public void UpdateJump()
        {
            if(_rigidbody.velocity.y < 0 && _rigidbody.position.y <= _startJumpVerticalPos)
            {
                ResetJump();
                return;
            }
        }

        private void ResetJump()
        {
            IsJumping = false;
            _rigidbody.position = new Vector2(_rigidbody.position.x, _startJumpVerticalPos);
            _rigidbody.gravityScale = 0;
        }
    }
}
