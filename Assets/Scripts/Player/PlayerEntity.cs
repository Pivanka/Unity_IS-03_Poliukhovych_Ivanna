using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core.Tools;
using Core.Enum;
using Core.Movement.Data;
using Core.Movement.Controller;
using Core;
using StatsSystem;

namespace Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerEntity : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private DirectionalMovementData _directionalMovementData;
        [SerializeField] private JumpData _jumpData;
        [SerializeField] private DirectionalCameraPair _cameras;

        private Rigidbody2D _rigidbody;
        private bool _isJumping;
        private DirectionalMover _directionalMover;
        private Jumper _jumper;
        private AnimationType _currentAnimationType;

        public void Initialize(IStatValueGiver statValueGiver)
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _directionalMover = new DirectionalMover(_rigidbody, _directionalMovementData, statValueGiver);
            _jumper = new Jumper(_rigidbody, _jumpData, statValueGiver);
        }

        private void Update()
        {
            if (_jumper.IsJumping)
                _jumper.UpdateJump();

            UpdateAnimations();
            UpdateCameras();
        }

        private void UpdateCameras()
        {
            foreach (var cameraPair in _cameras.DirectionalCameras)
                cameraPair.Value.enabled = cameraPair.Key == _directionalMover.Direction;
            
        }

        private void UpdateAnimations()
        {
            PlayAnimation(AnimationType.Idle, true);
            PlayAnimation(AnimationType.Run, _directionalMover.IsMoving);
            PlayAnimation(AnimationType.Jump, _isJumping);
        }

        public void MoveHorizontally(float direction) => _directionalMover.MoveHorizontally(direction);

        public void MoveVertically(float direction)
        {
            if (_jumper.IsJumping)
                return;

            _directionalMover.MoveVertically(direction);
        }

        public void Jump() => _jumper.Jump();

        private void PlayAnimation(AnimationType type, bool active)
        {
            if(!active)
            {
                if(_currentAnimationType == AnimationType.Idle || _currentAnimationType != type)
                    return;

                _currentAnimationType = AnimationType.Idle;
                PlayAnimation(_currentAnimationType);
                return;
            }

            if (_currentAnimationType >= type)
                return;

            _currentAnimationType = type;
            PlayAnimation(_currentAnimationType);
        }

        private void PlayAnimation(AnimationType type)
        {
            _animator.SetInteger(nameof(AnimationType), (int)type);
        }
    }
}
