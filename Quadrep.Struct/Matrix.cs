using System.Runtime.InteropServices;

namespace Quadrep.Struct
{
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct Matrix4f
    {
        public float r00;
        public float r01;
        public float r02;
        public float r03;

        public float r10;
        public float r11;
        public float r12;
        public float r13;

        public float r20;
        public float r21;
        public float r22;
        public float r23;

        public float r30;
        public float r31;
        public float r32;
        public float r33;


        public Matrix4f(float r_00, float r_01, float r_02, float r_03,
                        float r_10, float r_11, float r_12, float r_13,
                        float r_20, float r_21, float r_22, float r_23,
                        float r_30, float r_31, float r_32, float r_33)
        {
            r00 = r_00; r01 = r_01; r02 = r_02; r03 = r_03;
            r10 = r_10; r11 = r_11; r12 = r_12; r13 = r_13;
            r20 = r_20; r21 = r_21; r22 = r_22; r23 = r_23;
            r30 = r_30; r31 = r_31; r32 = r_32; r33 = r_33;
        }
    }
}
