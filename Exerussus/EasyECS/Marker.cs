using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;

namespace Source.Scripts.Logic
{
    public static class Marker
    {
        public static void Add<T>(EcsPool<T> ecsPool, int entity) where T : struct
        {
            if (!ecsPool.Has(entity)) ecsPool.Add(entity);
        }
    
        public static void Del<T>(EcsPool<T> ecsPool, int entity) where T : struct
        {
            ecsPool.Del(entity);
        }
        
        public static void Add<T>(EcsPoolInject<T> ecsPool, int entity) where T : struct
        {
            if (!ecsPool.Value.Has(entity)) ecsPool.Value.Add(entity);
        }
    
        public static void Del<T>(EcsPoolInject<T> ecsPool, int entity) where T : struct
        {
            ecsPool.Value.Del(entity);
        }
    
        public static bool Has<T>(EcsPool<T> ecsPool, int entity) where T : struct
        {
            return ecsPool.Has(entity);
        }
    
        public static bool Has<T>(EcsPoolInject<T> ecsPool, int entity) where T : struct
        {
            return ecsPool.Value.Has(entity);
        }
    }
}