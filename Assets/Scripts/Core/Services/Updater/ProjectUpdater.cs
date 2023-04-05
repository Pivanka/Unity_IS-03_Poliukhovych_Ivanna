﻿using System;
using System.Security.Cryptography;
using UnityEngine;

namespace Core.Services.Updater
{
    public class ProjectUpdater : MonoBehaviour, IProjectUpdater
    {
        public static IProjectUpdater Instance;
        
        public event Action UpdateCalled;
        public event Action FixedUpdatedCalled;
        public event Action LateUpdateCalled;

        private bool _isPaused;

        public bool IsPaused
        {
            get => _isPaused;
            set
            {
                if (_isPaused == value)
                    return;
                
                Time.timeScale = value ? 0 : 1;
                _isPaused = value;
            }
        }

        private void Awake()
        {
            if (Instance == null)
                Instance = this;
            else
                Destroy(gameObject);
        }
        
        private void Update()
        {
            UpdateCalled?.Invoke();
        }
        
        private void FixedUpdate()
        {
            if (IsPaused)
                return;
            
            FixedUpdatedCalled?.Invoke();
        }
        
        private void LateUpdate()
        {
            if (IsPaused)
                return;

            LateUpdateCalled?.Invoke();
        }
    }
}