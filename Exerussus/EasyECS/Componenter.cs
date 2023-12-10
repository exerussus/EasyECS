using System;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;

namespace Source.Scripts.Logic
{
    public static class Componenter
    {
        public static ref T Add<T>(EcsPool<T> ecsPool, int entity) where T : struct
        {
            if (!ecsPool.Has(entity))
            {
                return ref ecsPool.Add(entity);
            }
            return ref ecsPool.Get(entity);
        }
        
        public static ref T Add<T>(EcsPoolInject<T> ecsPool, int entity) where T : struct
        {
            if (!ecsPool.Value.Has(entity))
            {
                return ref ecsPool.Value.Add(entity);
            }
            return ref ecsPool.Value.Get(entity);
        }
        
        
        public static ref T GetFirstEntityComponent<T>(EcsWorld ecsWorld) where T : struct
        {
            foreach (var entity in ecsWorld.Filter<T>().End())
            {
                return ref ecsWorld.GetPool<T>().Get(entity);
            }
            throw new InvalidOperationException("Фильтр пуст");
        }

    }
}