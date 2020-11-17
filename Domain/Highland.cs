namespace Domain
{
    public class Highland
    {
        public int Boundary_X { get; private set; }
        public int Boundary_Y { get; private set; }

        public Highland(int boundary_X, int boundary_Y)
        {
            Boundary_X = boundary_X;
            Boundary_Y = boundary_Y;
        }
    }
}