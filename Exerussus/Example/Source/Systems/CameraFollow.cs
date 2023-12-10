
using Exerussus.Example.Source.Data.Components;
using Leopotam.EcsLite;
using Source.Scripts.Logic;
using UnityEngine;

namespace Exerussus.Example.Source.Systems
{
    public class CameraFollow : IEcsInitSystem, IEcsRunSystem
    {
        private EcsWorld _world;
        private ExampleGameShare _gameShare;
        private Transform _cameraTransform;
        private Transform _playerTransform;
        
        
        public void Init(IEcsSystems systems)
        {
            _world = systems.GetWorld();
            _gameShare = systems.GetShared<ExampleGameShare>();
            _cameraTransform = _gameShare.Camera.transform;
            _playerTransform = Componenter.GetFirstEntityComponent<TransformData>(_world).Value;
        }

        public void Run(IEcsSystems systems)
        {
            var cameraPos = _cameraTransform.position;
            var playerPos = _playerTransform.position;
            _cameraTransform.position = new Vector3(playerPos.x, playerPos.y, cameraPos.z);
        }
    }
}