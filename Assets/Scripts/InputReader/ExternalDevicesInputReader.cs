using System;
using System.Collections;
using System.Collections.Generic;
using Core.Services.Updater;
using UnityEngine;
using Player;
using Unity.VisualScripting;

namespace InputReader
{
    public class ExternalDevicesInputReader : IEntityInputSource, IDisposable
    {
        public float HorizontalDirection => Input.GetAxisRaw("Horizontal");
        public float VerticalDirection => Input.GetAxisRaw("Vertical");
        public bool Jump { get; private set; }

        public ExternalDevicesInputReader()
        {
            ProjectUpdater.Instance.UpdateCalled += OnUpdate;
        }
        
        public void ResetOneTimeActions()
        {
            Jump = false;
        }
        
        private void OnUpdate()
        {
            if (Input.GetButtonDown("Jump"))
                Jump = true;
        }

        public void Dispose() => ProjectUpdater.Instance.UpdateCalled -= OnUpdate;
    }
}

