namespace Quadrep.Struct
{
    public class RobotAndAuxCoordinate
    {
        public RobotCoordinate RobotCoor;
        public AuxCoordinate Aux;

        public RobotAndAuxCoordinate()
        {
            RobotCoor = new RobotCoordinate(); Aux = new AuxCoordinate();
        }
        public RobotAndAuxCoordinate(RobotCoordinate robotCoor, float aux1, float aux2, float aux3)
        {
            RobotCoor = robotCoor;
            Aux = new AuxCoordinate(aux1, aux2, aux3);
        }

        public RobotAndAuxCoordinate(RobotCoordinate robotCoor, AuxCoordinate aux)
        {
            RobotCoor = robotCoor; Aux = aux;
        }
    }

    
}
