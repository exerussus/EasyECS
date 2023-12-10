using System;
using Leopotam.EcsLite;

namespace Source.Scripts.Logic
{
    public static class Filter
    {
        public static bool AnyExist(EcsFilter filter)
        {
            foreach (var _ in filter)
            {
                return true;
            }
            return false;
        }

        public static int Length(EcsFilter filter)
        {
            var length = 0;
            
            foreach (var _ in filter)
            {
                length++;
            }
            return length;
        }
        
        public static int GetFirstEntity(EcsFilter filter)
        {
            foreach (var entity in filter)
            {
                return entity;
            }
            throw new InvalidOperationException("Фильтр пуст");
        }
    }
}