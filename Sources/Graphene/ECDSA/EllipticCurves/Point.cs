using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ECDSA.EllipticCurves
{
    public class Point
    {
        public CurveBase Curve { get; set; }
        public BigInteger X { get; set; }
        public BigInteger Y { get; set; }

        public int CompareTo(Point other)
        {
            throw new NotImplementedException();
        }

        public static bool operator == (Point c1, Point c2)
        {
            if(c1 == null && c2 == null)


            if (c1.Curve != c2.Curve)
                return false;


        }

        public static bool operator !=(Point c1, Point c2)
        {
            return !(c1 == c2);
        }
    }
}
