using OpenTK;
using Quadrep.Struct;
using System.Runtime.InteropServices;

namespace QuadrepAPI
{
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct vector3f
    {
        public float X;
        public float Y;
        public float Z;

        public vector3f(float x = 0, float y = 0, float z = 0)
        {
            X = x; Y = y; Z = z;
        }

        public static implicit operator Vector3(vector3f v)
            => new Vector3(v.X, v.Y, v.Z);

        public static implicit operator vector3f(Vector3 v)
            => new vector3f(v.X, v.Y, v.Z);
    }

    [StructLayout(LayoutKind.Sequential)]
    internal unsafe struct robotWorldCoordinate
    {
        public float X;
        public float Y;
        public float Z;
        public float A;
        public float B;
        public float C;

        public robotWorldCoordinate(float x = 0, float y = 0, float z = 0, float a = 0, float b = 0, float c = 0)
        {
            X = x; Y = y; Z = z; A = a; B = b; C = c;
        }

        public static implicit operator RobotWorldCoordinate(robotWorldCoordinate v)
            => new RobotWorldCoordinate(v.X, v.Y, v.Z, v.A, v.B, v.C);

        public static implicit operator robotWorldCoordinate(RobotWorldCoordinate v)
           => new robotWorldCoordinate(v.X, v.Y, v.Z, v.A, v.B, v.C);
    }
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct robotJointCoordinate
    {
        public float J1;
        public float J2;
        public float J3;
        public float J4;
        public float J5;
        public float J6;

        public robotJointCoordinate(float j1 = 0, float j2 = 0, float j3 = 0, float j4 = 0, float j5 = 0, float j6 = 0)
        {
            J1 = j1; J2 = j2; J3 = j3; J4 = j4; J5 = j5; J6 = j6;
        }

        public static implicit operator RobotJointCoordinate(robotJointCoordinate v)
            => new RobotJointCoordinate(v.J1, v.J2, v.J3, v.J4, v.J5, v.J6);

        public static implicit operator robotJointCoordinate(RobotJointCoordinate v)
           => new robotJointCoordinate(v.J1, v.J2, v.J3, v.J4, v.J5, v.J6);
    }
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
