using Exerussus.Example.Source;
using Exerussus.Example.Source.Components;
using Exerussus.Example.Source.Data.Components;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using Source.Scripts.Logic;
using UnityEngine;


namespace Plugins.Exerussus.Example.Source.Systems
{
    public class PlayerKeyListener : IEcsInitSystem, IEcsRunSystem
    {
        private EcsWorld _world;
        private ExampleGameShare _gameShare;
        private int _playerEntity;
        private EcsPoolInject<MovementDirection> _movementDirectionPool;
        
        public void Init(IEcsSystems systems)
        {
            _world = systems.GetWorld();
            _gameShare = systems.GetShared<ExampleGameShare>();
            _playerEntity = Filter.GetFirstEntity(_world.Filter<PlayerMark>().End());
        }

        public void Run(IEcsSystems systems)
        {
            var horizontalAxis = Input.GetAxis("Horizontal");
            var verticalAxis = Input.GetAxis("Vertical");

            if (horizontalAxis != 0 || verticalAxis != 0)
            {
                ref var movementDirection = ref Componenter.Add(_movementDirectionPool, _playerEntity);  // <-- This method returns the component if it exists. 
                movementDirection.Value = new Vector2(horizontalAxis, verticalAxis);
            }
        }
    }
}