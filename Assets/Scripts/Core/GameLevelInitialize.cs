using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;

namespace Core
{
    public class GameLevelInitialize : MonoBehaviour
    {
        [SerializeField] private PlayerEntity _playerEntity;
        [SerializeField] private GameUIInputView _gameUIInputView;

        private ExternalDevicesInputReader _externalDevicesInput;
        private PlayerBrain _playerBrain;

        private void Awake()
        {
            _externalDevicesInput = new ExternalDevicesInputReader();
            _playerBrain = new PlayerBrain(_playerEntity, new List<IEntityInputSource>
            {
                _gameUIInputView,
                _externalDevicesInput
            });

        }

        private void Update()
        {
            _externalDevicesInput.OnUpdate();
        }

        private void FixedUpdate()
        {
            _playerBrain.OnFixedUpdate();
        }
    }
}
