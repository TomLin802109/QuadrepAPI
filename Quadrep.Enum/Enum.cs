using System;

namespace Quadrep.Enum
{
    public enum EulerAngleType { ZYZ, XYZ, ZYX, None }
    public enum RotateAxis { X, _X, Y, _Y, Z, _Z, None }
    public enum Coordinate { Base, Tool, Joint, None }
    public enum MoveMode { MoveJ, MoveL, None }
    public enum JogMode { Continue, Inching, None }
    public enum JogSpeed { Level1, Level2, Level3, Level4, Level5, NoNE }
    public enum JogDirection
    {
        X1P = 1, X1N = 2, Y2P = 3, Y2N = 4, Z3P = 5, Z3N = 6, 
        A4P = 7, A4N = 8, B5P = 9, B5N = 10, C6P = 11, C6N = 12,
        None
    }
    public enum WeldingStatus { None, ReadyToScan, ReadyToCalsculate, ReadyToWelding }
}
