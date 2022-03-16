using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace QuadrepAPI.Kinemics
{
    internal static partial class KinemicsInvoke
    {
        [DllImport(Native.DllName, CallingConvention = Native.CallingConvention)]
        public static extern void SetJ1Parameter(int rotateAxis, vector3f vector);
        [DllImport(Native.DllName, CallingConvention = Native.CallingConvention)]
        public static extern void SetJ2Parameter(int rotateAxis, vector3f vector);
        [DllImport(Native.DllName, CallingConvention = Native.CallingConvention)]
        public static extern void SetJ3Parameter(int rotateAxis, vector3f vector);
        [DllImport(Native.DllName, CallingConvention = Native.CallingConvention)]
        public static extern void SetJ4Parameter(int rotateAxis, vector3f vector);
        [DllImport(Native.DllName, CallingConvention = Native.CallingConvention)]
        public static extern void SetJ5Parameter(int rotateAxis, vector3f vector);
        [DllImport(Native.DllName, CallingConvention = Native.CallingConvention)]
        public static extern void SetJ6Parameter(int rotateAxis, vector3f vector);
        [DllImport(Native.DllName, CallingConvention = Native.CallingConvention)]
        public static extern void SetTool(robotWorldCoordinate tool);
        [DllImport(Native.DllName, CallingConvention = Native.CallingConvention)]
        public static extern void SetPostureConfig(bool shoulderRight, bool elbowUp, bool nonFilp);


        [DllImport(Native.DllName, CallingConvention = Native.CallingConvention)]
        public static extern robotWorldCoordinate GetForwardKinemic_Yaskawa(robotJointCoordinate joint);
        [DllImport(Native.DllName, CallingConvention = Native.CallingConvention)]
        public static extern robotJointCoordinate GetInverseKinemic_Yaskawa(robotWorldCoordinate rwc);

        [DllImport(Native.DllName, CallingConvention = Native.CallingConvention)]
        public static extern robotWorldCoordinate GetForwardKinemic_Kawasaki(robotJointCoordinate joint);
        [DllImport(Native.DllName, CallingConvention = Native.CallingConvention)]
        public static extern robotJointCoordinate GetInverseKinemic_Kawasaki(robotWorldCoordinate joint);

    }
}
