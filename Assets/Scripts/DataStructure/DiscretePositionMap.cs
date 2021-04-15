using System.Collections.Generic;
using UnityEngine;

namespace DataStructure
{
    public class DiscretePositionMap<T>
    {
        private readonly Dictionary<Vector3, T> _map;

        public DiscretePositionMap()
        {
            _map = new Dictionary<Vector3, T>();
        }

        public bool Occupied(Vector3 position)
        {
            return _map.ContainsKey(position) && _map[position] != null;
        }

        public T Get(Vector3 position)
        {
            return _map[position];
        }

        public bool Set(Vector3 position, T o)
        {
            if (!Occupied(position))
            {
                _map[position] = o;
                return true;
            }

            return false;
        }

        public bool Relocate(Vector3 sourcePosition, Vector3 targetPosition)
        {
            if (Occupied(sourcePosition))
            {
                T sourceObject = Get(sourcePosition);

                if (!Occupied(targetPosition))
                {
                    _map[targetPosition] = sourceObject;
                    _map[sourcePosition] = default;
                    return true;
                }

                return false;
            }

            return false;
        }
    }
}