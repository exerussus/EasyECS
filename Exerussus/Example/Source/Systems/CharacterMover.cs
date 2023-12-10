
using Exerussus.Example.Source.Data.Components;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using UnityEngine;

namespace Exerussus.Example.Source.Systems
{
    public class CharacterMover : IEcsInitSystem, IEcsRunSystem
    {
    
        private EcsWorld _world;
        private ExampleGameShare _gameShare;
        private EcsFilter _characterMovementFilter;

        private EcsPool<RigidbodyData> _rigidbodyPool;  //  <-- Need to initialize. Working in abstraction
        private EcsPoolInject<MovementDirection> _movementDirectionPool;  //  <-- Doesn't need to init. Doesn't work in abstraction
        private EcsPoolInject<Speed> _speedPool;
            
        public void Init(IEcsSystems systems)
        {
            _world = systems.GetWorld();
            _gameShare = systems.GetShared<ExampleGameShare>();
            _rigidbodyPool = _world.GetPool<RigidbodyData>();
            _characterMovementFilter = _world.Filter<RigidbodyData>().Inc<MovementDirection>().Inc<Speed>().End();
        }

        public void Run(IEcsSystems systems)
        {
            foreach (var entity in _characterMovementFilter)
            {
                ref var rigidbody = ref _rigidbodyPool.Get(entity);
                ref var movementDirection = ref _movementDirectionPool.Value.Get(entity);
                ref var speed = ref _speedPool.Value.Get(entity);
                
                rigidbody.Value.velocity += movementDirection.Value * (Time.fixedDeltaTime * speed.Value);
            }
        }
    }
}
