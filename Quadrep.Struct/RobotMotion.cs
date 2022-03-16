namespace Quadrep.Struct
{
    public enum SpeedMode { Linear, Degree, Time };

    public class RobotMotionPoint
    {
        public RobotJointCoordinate JointCoordinate { get; protected set; }
        public RobotWorldCoordinate WorldCoordinate { get; protected set; }
        
        public SpeedMode SpeedMode { get; protected set; }
        public float Speed { get; protected set; } = float.NaN;
        public float Accuracy { get; protected set; }

        public RobotMotionPoint()
        {
            WorldCoordinate = null; JointCoordinate = null;
            Speed = float.NaN; Accuracy = float.NaN;
        }

        public RobotMotionPoint(RobotJointCoordinate rjc, SpeedMode speedMode, float speed, float acc)
        {
            JointCoordinate = rjc; Speed = speed; Accuracy = acc;
            WorldCoordinate = null; SpeedMode = speedMode;
        }
        public RobotMotionPoint(RobotJointCoordinate rjc, float speed, float acc)
        {
            JointCoordinate = rjc; Speed = speed; Accuracy = acc;
            WorldCoordinate = null; SpeedMode = SpeedMode.Linear;
        }
        public RobotMotionPoint(RobotWorldCoordinate rwc, SpeedMode speedMode, float speed, float acc)
        {
            WorldCoordinate = rwc; Speed = speed; Accuracy = acc;
            JointCoordinate = null; SpeedMode = speedMode;
        }
        public RobotMotionPoint(RobotWorldCoordinate rwc, float speed, float acc)
        {
            WorldCoordinate = rwc; Speed = speed; Accuracy = acc;
            JointCoordinate = null; SpeedMode = SpeedMode.Linear;
        }
        public override string ToString()
        {
            var crdStr = WorldCoordinate == null ? $"Joint,{JointCoordinate}" : $"World,{WorldCoordinate}";
            var spType = string.Empty;
            switch (SpeedMode)
            {
                case SpeedMode.Degree:
                    spType = $",D";
                    break;
                case SpeedMode.Time:
                    spType = $",T";
                    break;
            }
            return crdStr + $",{Speed:F2},{Accuracy:F2}"+ spType;
        }
    }
}
