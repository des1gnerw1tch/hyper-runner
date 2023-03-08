using System.Collections.Generic;
using UnityEngine;

namespace Utils.List
{
    /// <summary>
    /// Transform position X axis comparer.
    /// </summary>
    public class TransformXComparer : IComparer<Transform>
    {
        public int Compare(Transform t1, Transform t2)
        {
            if (t1.position.x <= t2.position.x)
            {
                return -1;
            }
            else
            {
                return 1;
            }
        }
    }
}
