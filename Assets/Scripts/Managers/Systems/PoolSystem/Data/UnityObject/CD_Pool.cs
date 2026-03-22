using System.Collections.Generic;
using Systems.PoolSystem.Data.VisualObject;
using UnityEngine;

namespace Systems.PoolSystem.Data.UnityObject
{
    [CreateAssetMenu(fileName = "CD_Pool", menuName = "Pooling/CD_Pool")]
    public class CD_Pool : ScriptableObject
    {
        public List<PoolVO> pools;
    }

}
