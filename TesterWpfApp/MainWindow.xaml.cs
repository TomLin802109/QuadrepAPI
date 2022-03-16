using OCCTSharpFramework;
using OpenTK;
using Quadrep;
using Quadrep.Struct;
using QuadrepAPI;
using QuadrepAPI.Kinemics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TesterWpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
            var j1 = 45f; var j2 = -45f; var j3 = -45f; var j4 = 45f;var j5 = 90;var j6 = -45f;
            var j1c = new vector3f(); var j2c = new vector3f(); var j3c = new vector3f();
            var j4c = new vector3f(); var j5c = new vector3f(); var j6c = new vector3f();

            var tcp = new RobotWorldCoordinate(305.149891f, 205.149891f, 1013.452885f, 144.735610f, 30f, 9.735610f);

            var j2Center = new Vector3(109.601551f, 109.601551f, 450f);
            var j2_tx = Vector3.UnitX.RotateZ(j1.ToRad());
            var j2_ty = Vector3.UnitY.RotateZ(j1.ToRad());
            var j2_tz = Vector3.UnitZ.RotateZ(j1.ToRad());

            var j3Center = j2Center+new Vector3(0,0,614).RotateZ(j1.ToRad()).RotateY(j2.ToRad());
            var j3_tx = Vector3.UnitX.RotateZ(j1.ToRad()).RotateY(j2.ToRad());
            var j3_ty = Vector3.UnitY.RotateZ(j1.ToRad()).RotateY(j2.ToRad());
            var j3_tz = Vector3.UnitZ.RotateZ(j1.ToRad()).RotateY(j2.ToRad());

            var j5Center = new Vector3(225.149891f, 225.149891f, 1084.163563f);
            var j5_tx = Vector3.UnitX.RotateZ(j1.ToRad()).RotateY(j2.ToRad()).RotateY(-j3.ToRad()).RotateX(-j4.ToRad());
            var j5_ty = Vector3.UnitY.RotateZ(j1.ToRad()).RotateY(j2.ToRad()).RotateY(-j3.ToRad()).RotateX(-j4.ToRad());
            var j5_tz = Vector3.UnitZ.RotateZ(j1.ToRad()).RotateY(j2.ToRad()).RotateY(-j3.ToRad()).RotateX(-j4.ToRad());
            //
            var tx = Vector3.UnitX.RotateXYZ(tcp.A.ToRad(), tcp.B.ToRad(), tcp.C.ToRad());
            var ty = Vector3.UnitY.RotateXYZ(tcp.A.ToRad(), tcp.B.ToRad(), tcp.C.ToRad());
            var tz = Vector3.UnitZ.RotateXYZ(tcp.A.ToRad(), tcp.B.ToRad(), tcp.C.ToRad());
            
            tkcontrol_show.ClearElement();
            tkcontrol_show.AddElement(new TKPoint(new Vector3(tcp.X,tcp.Y,tcp.Z)/10, System.Drawing.Color.Blue, 5));
            DrawCoordinate(new Vector3(tcp.X, tcp.Y, tcp.Z)/10, tx, ty, tz, 10);
            tkcontrol_show.AddElement(new TKPoint(j2Center / 10, System.Drawing.Color.Magenta, 5));
            DrawCoordinate(j2Center / 10, j2_tx, j2_ty, j2_tz, 10);
            tkcontrol_show.AddElement(new TKPoint(j3Center/10, System.Drawing.Color.White, 5));
            DrawCoordinate(j3Center / 10, j3_tx, j3_ty, j3_tz, 10);

            tkcontrol_show.AddElement(new TKPoint(j5Center / 10, System.Drawing.Color.White, 5));
            DrawCoordinate(j5Center / 10, j5_tx, j5_ty, j5_tz, 10);
            tkcontrol_show.Invalidate();


            var cadMoudel = ReadCADModule.ReadXML("Simulation.proj").ToArray();
            var p = ToolToBaseCoordinate.GetRobotWorldAtBase(new Vector3(0, 500, 300), Vector3.UnitX, -Vector3.UnitY, -Vector3.UnitZ, Quadrep.Enum.EulerAngleType.ZYZ);
            //InverseKinemics invKinemics = new InverseKinemics_Kawasaki(cadMoudel[0], new Vector3(0, 0, 0));
            //var j = invKinemics.GetJointCoordinate(p);
            //ForwardKinemics fwKinemics = new ForwardKinemics_Kawasaki(cadMoudel[0], new Vector3(0, 0, 0));
            //var w = fwKinemics.GetForwardWorldCoordinate(j.J1, j.J2, j.J3, j.J4, j.J5, j.J6);
            var module = cadMoudel[0];


            //Console.WriteLine($"{p}");
            //Console.WriteLine($"{j}");
            //Console.WriteLine($"{w}");
            //Console.ReadLine();


        }

        public void DrawCoordinate(Vector3 loc, Vector3 xAxis, Vector3 yAxis, Vector3 zAxis, float len)
        {
            tkcontrol_show.AddElement(new TKLine(loc, loc + xAxis*len, System.Drawing.Color.Red, System.Drawing.Color.Red, 1));
            tkcontrol_show.AddElement(new TKLine(loc, loc + yAxis*len, System.Drawing.Color.Green, System.Drawing.Color.Green, 1));
            tkcontrol_show.AddElement(new TKLine(loc, loc + zAxis*len, System.Drawing.Color.Blue, System.Drawing.Color.Blue, 1));
            tkcontrol_show.Invalidate();
        }
    }
}
