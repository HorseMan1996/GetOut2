using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.DataScripts.CD_Data
{
    [CreateAssetMenu(fileName = "CD_GameVersion", menuName = "ScriptableObjects/CD_GameVersion", order = 1)]
    public class CD_GameVersion : ScriptableObject
    {
        public List<byte> GameVersion;
    }

}
