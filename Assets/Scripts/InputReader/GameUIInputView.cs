using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace InputReader
{
    public class GameUIInputView : MonoBehaviour, IEntityInputSource
    {
        [SerializeField] private Joystick _joystick;
        [SerializeField] private Button _jumpButton;

        public float HorizontalDirection => _joystick.Horizontal;
        public float VerticalDirection => _joystick.Vertical;

        public bool Jump { get; private set; }

        public void ResetOneTimeActions()
        {
            Jump = false;
        }

        private void Awake()
        {
            _jumpButton.onClick.AddListener(() => Jump = true);
        }

        private void OnDestroy()
        {
            _jumpButton.onClick.RemoveAllListeners();
        }
    }
}
