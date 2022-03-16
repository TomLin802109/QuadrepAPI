using Quadrep.CAD;
using Quadrep.Struct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuadrepAPI.Kinemics
{
    public abstract class Kinemics
    {
        public RobotWorldCoordinate Tool { get; protected set; }
        public Kinemics(CADModule module, RobotWorldCoordinate tool)
        {
            Tool = tool;
            KinemicsInvoke.SetTool(tool);
            KinemicsInvoke.SetJ1Parameter((int)module.Elements[1].RotationDirection,
                                    module.Elements[0].ElementPosition);
            KinemicsInvoke.SetJ2Parameter((int)module.Elements[2].RotationDirection,
                                    module.Elements[1].ElementPosition);
            KinemicsInvoke.SetJ3Parameter((int)module.Elements[3].RotationDirection,
                                    module.Elements[2].ElementPosition);
            KinemicsInvoke.SetJ4Parameter((int)module.Elements[4].RotationDirection,
                                    module.Elements[3].ElementPosition);
            KinemicsInvoke.SetJ5Parameter((int)module.Elements[5].RotationDirection,
                                    module.Elements[5].ElementPosition);
            KinemicsInvoke.SetJ6Parameter((int)module.Elements[6].RotationDirection,
                                    module.Elements[6].ElementPosition);
            if (module.Elements.Count < 7)
                throw new ArgumentException($"CAD module elements involved {module.Elements.Count} axis. At least 7 element");
        }
        public abstract RobotWorldCoordinate GetForwardKinemic(RobotJointCoordinate rjc);
        public abstract RobotJointCoordinate GetInverseKinemic(RobotWorldCoordinate rwc, PostureConfig cfg);
    }

    public class YaskawaKinemics : Kinemics
    {
        public YaskawaKinemics(CADModule module, RobotWorldCoordinate tool) : base(module, tool)
        {

        }
        public override RobotWorldCoordinate GetForwardKinemic(RobotJointCoordinate rjc)
        {
            return KinemicsInvoke.GetForwardKinemic_Yaskawa(rjc);
        }

        public override RobotJointCoordinate GetInverseKinemic(RobotWorldCoordinate rwc, PostureConfig cfg)
        {
            KinemicsInvoke.SetPostureConfig(cfg.ShoulderRight, cfg.ElbowUp, cfg.NonFlip);
            return KinemicsInvoke.GetInverseKinemic_Yaskawa(rwc);
        }
    }

    public class KawasakiKinemics : Kinemics
    {
        public KawasakiKinemics(CADModule module, RobotWorldCoordinate tool) : base(module, tool)
        {

        }
        public override RobotWorldCoordinate GetForwardKinemic(RobotJointCoordinate rjc)
        {
            return KinemicsInvoke.GetForwardKinemic_Kawasaki(rjc);
        }

        public override RobotJointCoordinate GetInverseKinemic(RobotWorldCoordinate rwc, PostureConfig cfg)
        {
            KinemicsInvoke.SetPostureConfig(cfg.ShoulderRight, cfg.ElbowUp, cfg.NonFlip);
            return KinemicsInvoke.GetInverseKinemic_Kawasaki(rwc);
        }
    }
}
