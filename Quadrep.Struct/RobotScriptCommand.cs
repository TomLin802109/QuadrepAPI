using System;
using System.Collections.Generic;
using System.Text;

namespace Quadrep.Struct
{
    public abstract class RobotScriptCommand
    {
        protected string CommandName { get; set; }
        protected string CommandParameters { get; set; }
        public override string ToString() => $"{CommandName},{CommandParameters}";
    }

    public class MotionCommand : RobotScriptCommand
    {
        public MotionCommand(RobotMotionPoint rmp)
        {
            CommandName = rmp.WorldCoordinate == null ? "Joint" : "World";
            CommandParameters = rmp.WorldCoordinate == null ? $"{rmp.JointCoordinate}" : $"{rmp.WorldCoordinate}" +
                                $"{rmp.Speed},{rmp.Accuracy},";
            switch (rmp.SpeedMode)
            {
                case SpeedMode.Time:
                    CommandParameters += "T";
                    break;
                case SpeedMode.Degree:
                    CommandParameters += "D";
                    break;
            }
        }

    }

    public class DICommand : RobotScriptCommand
    {
        public DICommand(int diNumber, bool state)
        {
            CommandName = "DI";
            CommandParameters = $"{diNumber}," + (state ? "On" : "Off");
        }
    }

    public class DOCommand : RobotScriptCommand
    {
        public DOCommand(int doNumber, bool state)
        {
            CommandName = "DO";
            CommandParameters = $"{doNumber}," + (state ? "On" : "Off");
        }
    }

    public class WaitTimeCommand : RobotScriptCommand
    {
        public WaitTimeCommand(int time)
        {
            CommandName = "DO";
            CommandParameters = $"{time}";
        }
    }

    public static class ScriptCommand
    {
        public static string MotionCommand(RobotMotionPoint motion) => motion.ToString();
        public static string MotionCommand(RobotJointCoordinate coordinate, float speed, float accuracy, SpeedMode mode = SpeedMode.Linear)
            => $"Joint,{coordinate},{speed},{accuracy}," + getSpeedModeString(mode);
        public static string MotionCommand(RobotWorldCoordinate coordinate, float speed, float accuracy, SpeedMode mode = SpeedMode.Linear)
            => $"World,{coordinate},{speed},{accuracy}," + getSpeedModeString(mode);
        private static string getSpeedModeString(SpeedMode mode)
        {
            switch (mode)
            {
                case SpeedMode.Time:
                    return "T";
                    break;
                case SpeedMode.Degree:
                    return "D";
                    break;
                default:
                    return string.Empty;
                    break;
            }
        }

        public static string DICommand(int diNumber, bool state) => $"DI,{diNumber}," + (state ? "On" : "Off");
        public static string DOCommand(int diNumber, bool state) => $"DI,{diNumber}," + (state ? "On" : "Off");
        public static string WaitTimeCommand(int time) => $"WaitTime,{time},";
    }
}
