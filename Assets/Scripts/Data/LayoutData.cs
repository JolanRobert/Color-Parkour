using System.Collections.Generic;
using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "New Layout", menuName = "Data/Layout", order = 0)]
    public class LayoutData : ScriptableObject
    {
        public List<GameObject> LayoutElements;
        public int MaxCoins;
    }
}