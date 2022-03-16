using System;

namespace Quadrep.Struct
{
    
    public class RobotWorldCoordinate
    {
        public float X { get; protected set; } = float.NaN;
        public float Y { get; protected set; } = float.NaN;
        public float Z { get; protected set; } = float.NaN;
        public float A { get; protected set; } = float.NaN;
        public float B { get; protected set; } = float.NaN;
        public float C { get; protected set; } = float.NaN;
        public float Aux1 { get; protected set; } = float.NaN;
        public float Aux2 { get; protected set; } = float.NaN;
        public float Aux3 { get; protected set; } = float.NaN;
        
        public RobotWorldCoordinate() { }
        public RobotWorldCoordinate(float x, float y, float z, float a, float b, float c, float aux1 = float.NaN, float aux2 = float.NaN, float aux3 = float.NaN)
        {
            X = x; Y = y; Z = z;
            A = a; B = b; C = c;
            Aux1 = aux1; Aux2 = aux2; Aux3 = aux3;
        }
        public RobotWorldCoordinate(float x, float y, float z, float a, float b, float c, AuxCoordinate aux)
        {
            X = x; Y = y; Z = z;
            A = a; B = b; C = c;
            Aux1 = aux.Aux1; Aux2 = aux.Aux2; Aux3 = aux.Aux3;
        }
        public RobotWorldCoordinate(RobotWorldCoordinate rwc, AuxCoordinate aux)
        {
            X = rwc.X; Y = rwc.Y; Z = rwc.Z;
            A = rwc.A; B = rwc.B; C = rwc.C;
            Aux1 = aux.Aux1; Aux2 = aux.Aux2; Aux3 = aux.Aux3;
        }

        public RobotWorldCoordinate(params float[] coor)
        {
            try
            {
                X = coor[0]; Y = coor[1]; Z = coor[2];
                A = coor[3]; B = coor[4]; C = coor[5];
                Aux1 = coor.Length >= 7 ? coor[6] : float.NaN;
                Aux2 = coor.Length >= 8 ? coor[7] : float.NaN;
                Aux3 = coor.Length >= 9 ? coor[8] : float.NaN;
            }
            catch
            {
                throw new System.Exception($"The length of argument is incorrect");
            }
        }
        public AuxCoordinate GetAuxCoordinate() => new AuxCoordinate(Aux1, Aux2, Aux3);
        public override string ToString()
        {
            var str = $"{X:F3},{Y:F3},{Z:F3},{A:F3},{B:F3},{C:F3}";
            if (!float.IsNaN(Aux1)) str += $",{Aux1:F3}";
            if (!float.IsNaN(Aux2)) str += $",{Aux2:F3}";
            if (!float.IsNaN(Aux3)) str += $",{Aux3:F3}";
            return str;
        }

        public RobotWorldCoordinate Trans(float x = 0, float y = 0, float z = 0, 
            float a = 0, float b = 0, float c = 0,
            float aux1 = 0, float aux2 = 0, float aux3 = 0)
            => new RobotWorldCoordinate(X + x, Y + y, Z + z, A + a, B + b, C + c, Aux1 + aux1, Aux2 + aux2, Aux3 + aux3);
    }
    
    public class RobotJointCoordinate
    {
        public float J1 { get; protected set; } = float.NaN;
        public float J2 { get; protected set; } = float.NaN;
        public float J3 { get; protected set; } = float.NaN;
        public float J4 { get; protected set; } = float.NaN;
        public float J5 { get; protected set; } = float.NaN;
        public float J6 { get; protected set; } = float.NaN;
        public float Aux1 { get; protected set; } = float.NaN;
        public float Aux2 { get; protected set; } = float.NaN;
        public float Aux3 { get; protected set; } = float.NaN;

        public RobotJointCoordinate() { }
        public RobotJointCoordinate(float j1, float j2, float j3, 
            float j4, float j5, float j6,
            float aux1 = float.NaN, float aux2 = float.NaN, float aux3 = float.NaN)
        {
            J1 = j1; J2 = j2; J3 = j3;
            J4 = j4; J5 = j5; J6 = j6;
            Aux1 = aux1; Aux2 = aux2; Aux3 = aux3;
        }
        public RobotJointCoordinate(float j1, float j2, float j3, float j4, float j5, float j6, AuxCoordinate aux)
        {
            J1 = j1; J2 = j2; J3 = j3;
            J4 = j4; J5 = j5; J6 = j6;
            Aux1 = aux.Aux1; Aux2 = aux.Aux2; Aux3 = aux.Aux3;
        }
        public RobotJointCoordinate(RobotJointCoordinate rjc, AuxCoordinate aux)
        {
            J1 = rjc.J1; J2 = rjc.J2; J3 = rjc.J3;
            J4 = rjc.J4; J5 = rjc.J5; J6 = rjc.J6;
            Aux1 = aux.Aux1; Aux2 = aux.Aux2; Aux3 = aux.Aux3;
        }
        public RobotJointCoordinate(params float[] coor)
        {
            try
            {
                J1 = coor[0]; J2 = coor[1]; J3 = coor[2];
                J4 = coor[3]; J5 = coor[4]; J6 = coor[5];
                Aux1 = coor.Length >= 7 ? coor[6] : float.NaN;
                Aux2 = coor.Length >= 8 ? coor[7] : float.NaN;
                Aux3 = coor.Length >= 9 ? coor[8] : float.NaN;
            }
            catch 
            {
                throw new System.Exception($"The length of argument is incorrect");
            }
        }

        public AuxCoordinate GetAuxCoordinate() => new AuxCoordinate(Aux1, Aux2, Aux3);

        public override string ToString()
        {
            var str = $"{J1:F3},{J2:F3},{J3:F3},{J4:F3},{J5:F3},{J6:F3}";
            if (!float.IsNaN(Aux1)) str += $",{Aux1:F3}";
            if (!float.IsNaN(Aux2)) str += $",{Aux2:F3}";
            if (!float.IsNaN(Aux3)) str += $",{Aux3:F3}";
            return str;
        }

        public RobotJointCoordinate Trans(float j1 = 0, float j2 = 0, float j3 = 0,
            float j4 = 0, float j5 = 0, float j6 = 0,
            float aux1 = 0, float aux2 = 0, float aux3 = 0)
            => new RobotJointCoordinate(J1 + j1, J2 + j2, J3 + j3, J4 + j4, J5 + j5, J6 + j6, Aux1 + aux1, Aux2 + aux2, Aux3 + aux3);
    }

    public class RobotCoordinate
    {
        public RobotWorldCoordinate WorldCoordinate { get; protected set; } = new RobotWorldCoordinate();
        public RobotJointCoordinate JointCoordinate { get; protected set; } = new RobotJointCoordinate();
        public RobotCoordinate() { }
        public RobotCoordinate(RobotWorldCoordinate worldCoordinate, RobotJointCoordinate jointCoordinate)
        {
            WorldCoordinate = worldCoordinate; JointCoordinate = jointCoordinate;
        }
    }

    public class JogDeltaCoordinate
    {
        public float DeltaX { get; private set; }
        public float DeltaY { get; private set; }
        public float DeltaZ { get; private set; }
        public float DeltaA { get; private set; }
        public float DeltaB { get; private set; }
        public float DeltaC { get; private set; }
        public float RobotMoveStep { get; private set; }

        public JogDeltaCoordinate(float x, float y, float z, float a, float b, float c, float robotMoveStep)
        {
            DeltaX = x; DeltaY = y; DeltaZ = z; DeltaA = a; DeltaB = b; DeltaC = c; RobotMoveStep = robotMoveStep;
        }

        public bool IsAllZero()
        {
            if (DeltaX == 0 && DeltaY == 0 && DeltaZ == 0 &&
               DeltaA == 0 && DeltaB == 0 && DeltaC == 0)
                return true;
            else
                return false;
        }

        public override string ToString()
            => $"{DeltaX:F3},{DeltaY:F3},{DeltaZ:F3},{DeltaA:F3},{DeltaB:F3},{DeltaC:F3},{RobotMoveStep:F3}";
    }

    public class AuxCoordinate
    {
        public float Aux1 { get; protected set; } = float.NaN;
        public float Aux2 { get; protected set; } = float.NaN;
        public float Aux3 { get; protected set; } = float.NaN;

        public AuxCoordinate()
        {
            Aux1 = 0; Aux2 = 0; Aux3 = 0;
        }

        public AuxCoordinate(float aux1, float aux2, float aux3)
        {
            Aux1 = aux1; Aux2 = aux2; Aux3 = aux3;
        }
    }

    //public class RobotMotionPoint
    //{
    //    public RobotJointCoordinate JointCoordinate { get; protected set; }
    //    public RobotWorldCoordinate WorldCoordinate { get; protected set; }
    //    public float Speed { get; protected set; }
    //    public float RotSpeed { get; protected set; }
    //    public float Time { get; protected set; }
    //    public float Acc { get; protected set; }

    //    public RobotMotionPoint()
    //    {
    //        WorldCoordinate = null; Speed = float.NaN; RotSpeed = float.NaN; Time = float.NaN; Acc = float.NaN;
    //        JointCoordinate = null;
    //    }
    //    public RobotMotionPoint(RobotWorldCoordinate rwc,float speed, float rotspeed, float acc)
    //    {
    //        WorldCoordinate = rwc; Speed = speed; RotSpeed = rotspeed; Time = float.NaN; Acc = acc;
    //        JointCoordinate = null;
    //    }
    //    public RobotMotionPoint(RobotWorldCoordinate rwc, float time, float acc)
    //    {
    //        WorldCoordinate = rwc; Speed = float.NaN; RotSpeed = float.NaN; Time = time; Acc = acc;
    //        JointCoordinate = null;
    //    }
    //    public RobotMotionPoint(RobotJointCoordinate rjc, float speed, float rotspeed, float acc)
    //    {
    //        JointCoordinate = rjc; Speed = speed; RotSpeed = rotspeed; Time = float.NaN; Acc = acc;
    //        WorldCoordinate = null;
    //    }
    //    public RobotMotionPoint(RobotJointCoordinate rjc, float time, float acc)
    //    {
    //        JointCoordinate = rjc; Speed = float.NaN; RotSpeed = float.NaN; Time = time; Acc = acc;
    //        WorldCoordinate = null;
    //    }
    //    public override string ToString()
    //    {
    //        var crdStr = WorldCoordinate == null ? $"Joint,{JointCoordinate}" : $"World,{WorldCoordinate}";
    //        return crdStr + $",{ Speed:F3},{RotSpeed:F3},{Time:F3},{Acc:F2}";        
    //    }
    //}

    public static partial class EXT
    {
        public static bool IsContainNan(this RobotWorldCoordinate robotWorldCoordinate)
            => float.IsNaN(robotWorldCoordinate.X) || float.IsNaN(robotWorldCoordinate.Y) || float.IsNaN(robotWorldCoordinate.Z) ||
               float.IsNaN(robotWorldCoordinate.A) || float.IsNaN(robotWorldCoordinate.B) || float.IsNaN(robotWorldCoordinate.C);

        public static bool IsContainNan(this RobotJointCoordinate robotJointCoordinate)
            => float.IsNaN(robotJointCoordinate.J1) || float.IsNaN(robotJointCoordinate.J2) || float.IsNaN(robotJointCoordinate.J3) ||
               float.IsNaN(robotJointCoordinate.J4) || float.IsNaN(robotJointCoordinate.J5) || float.IsNaN(robotJointCoordinate.J6);
    }
}
