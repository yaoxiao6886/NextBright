using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace RPGLogicBase
{
    [StructLayout(LayoutKind.Sequential, Size = 1)]
    public struct MathfInternal
    {
        public static volatile float FloatMinNormal = 1.17549435E-38f;

        public static volatile float FloatMinDenormal = 1.401298E-45f;

        public static bool IsFlushToZeroEnabled = MathfInternal.FloatMinDenormal == 0f;
    }
}
