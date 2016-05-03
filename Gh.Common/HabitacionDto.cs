namespace Gh.Common
{
    public class HabitacionDto : BaseDto
    {
        private int posicionX;
        private int posicionY;
        private double metrosCuadrados;

        public int PosicionX
        {
            get { return posicionX; }
            set { posicionX = value; }
        }

        public int PosicionY
        {
            get { return posicionY; }
            set { posicionY = value; }
        }

        public double MetrosCuadrados
        {
            get { return metrosCuadrados; }
            set { metrosCuadrados = value; }
        }
    }
}
