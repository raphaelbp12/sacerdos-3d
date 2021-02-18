using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scrds.Utils
{
    public class Math
    {
        public static float GetAngleFromVectorFloat(Vector3 dir) {
            dir = dir.normalized;
            float n = Mathf.Atan2(dir.x, dir.z) * Mathf.Rad2Deg;
            if (n < 0) n += 360;

            return n;
        }
    }
}