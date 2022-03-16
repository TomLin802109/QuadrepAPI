using Quadrep.Enum;
using System.Numerics;

namespace Quadrep.Struct
{
    public class RobotCADModel
    {
        public (Vector3 Shift, RotateAxis RotateDirection) baseInfo { get; set; }
        public (Vector3 Shift, RotateAxis RotateDirection) Joint1Info { get; set; }
        public (Vector3 Shift, RotateAxis RotateDirection) Joint2Info { get; set; }
        public (Vector3 Shift, RotateAxis RotateDirection) Joint3Info { get; set; }
        public (Vector3 Shift, RotateAxis RotateDirection) Joint4Info { get; set; }
        public (Vector3 Shift, RotateAxis RotateDirection) Joint5Info { get; set; }
        public (Vector3 Shift, RotateAxis RotateDirection) Joint6Info { get; set; }
        public string Robot { get; set; }
    }
}
