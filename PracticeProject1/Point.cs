
namespace PracticeProject
{
    public class Point
    {
        public double X;
        public double Y;
        public double Z;

        public Point(double x, double y, double z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }

        public static Point operator +(Point p1, Point p2) => new Point(p1.X + p2.X, p1.Y + p2.Y, p1.Z + p2.Z);

        public static Point operator -(Point p1, Point p2) => new Point(p1.X - p2.X, p1.Y - p2.Y, p1.Z - p2.Z);

        public static Point operator ++(Point p) => new Point(p.X + 1, p.Y + 1, p.Y + 1);

        public static Point operator --(Point p) => new Point(p.X - 1, p.Y - 1, p.Y - 1);

        public static bool operator ==(Point p1, Point p2) => (p1.X == p2.X && p1.Y == p2.Y && p1.Z == p2.Z);

        public static bool operator !=(Point p1, Point p2) => (p1.X != p2.X || p1.Y != p2.Y || p1.Z != p2.Z);

        public override string ToString()
        {
            return $"X = {X}, Y = {Y}, Z = {Z}";
        }
    }
}
