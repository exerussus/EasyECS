
using Exerussus.Example.Source.Components;
using Exerussus.Example.Source.Data.Components;
using Exerussus.Example.Source.MonoBehaviours;
using Leopotam.EcsLite;
using Source.Scripts.Logic;
using UnityEngine;

namespace Exerussus.Example.Source.Systems
{
    public class PlayerInitializer : IEcsInitSystem
    {
        public void Init(IEcsSystems systems)
        {
            var world = systems.GetWorld();
            var gameShare = systems.GetShared<ExampleGameShare>();
            
            var newGameObject = Object.Instantiate(gameShare.PlayerPrefab, gameShare.CharactersParentObject);
            var player = newGameObject.GetComponent<Player>();

            var playerEntity = world.NewEntity();

            Marker.Add(world.GetPool<PlayerMark>(), playerEntity); // <-- You can use my static class. Marks are only needed for identification
            ref var rigidbody = ref Componenter.Add(world.GetPool<RigidbodyData>(), playerEntity); // <-- You can use my static class.
            ref var speed = ref world.GetPool<Speed>().Add(playerEntity); // <-- Or not
            ref var playerTransform = ref world.GetPool<TransformData>().Add(playerEntity);

            rigidbody.Value = player.Rigidbody;
            speed.Value = player.Speed;
            playerTransform.Value = player.transform;
        }
    }
}
