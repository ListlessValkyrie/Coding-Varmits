using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerApp
{
    public static class ExtensionMethods
    {
        public static bool IsEndState(this PlayerState? playerState)
            => playerState == PlayerState.Dying;

        public static T Next<T>(this T src) where T : Enum
        {
            T[] values = (T[])Enum.GetValues(src.GetType());

            int nextIdx = Array.IndexOf<T>(values, src) + 1;

            return (values.Length == nextIdx)
                ? values[0] 
                : values[nextIdx];
        }
    }
}
