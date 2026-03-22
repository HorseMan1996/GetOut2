using Systems.PoolSystem.Enum;
using UnityEngine;

namespace Systems.PoolSystem.Data.VisualObject
{
    [System.Serializable]   
    public class PoolVO
    {
        public ObjectType key;
        public GameObject prefab;
        public int size = 10;
    }

}
