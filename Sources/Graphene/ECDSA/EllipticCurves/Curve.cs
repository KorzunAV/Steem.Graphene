namespace ECDSA.EllipticCurves
{
    public class CurveBase
    {
        protected System.Numerics.BigInteger A { get; set; }
        protected System.Numerics.BigInteger B { get; set; }
        protected System.Numerics.BigInteger P { get; set; }
        protected System.Numerics.BigInteger Gx { get; set; }
        protected System.Numerics.BigInteger Gy { get; set; }
        //order
        public System.Numerics.BigInteger R { get; set; }


        /// <summary>
        /// Is the point (x,y) on this curve?
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public virtual bool ContainsPoint(System.Numerics.BigInteger x, System.Numerics.BigInteger y)
        {
            return (y * y - (x * x * x + A * x + B)) % P == 0;
        }


        //    def find_curve(oid_curve):
        //for c in curves:
        //    if c.oid == oid_curve:
        //        return c
        //raise UnknownCurveError("I don't know about the curve with oid %s."
        //                        "I only know about these: %s" %
        //                        (oid_curve, [c.name for c in curves]))

        protected void Validate()
        {
            if (ContainsPoint(Gx, Gy))
            {
            }
        }

        private void Add(CurveBase curveBase)
        {
            // if(curveBase == )
        }


        //        def __mul__(self, other):
        //    """Multiply a point by an integer."""

        //    def leftmost_bit(x):
        //      assert x > 0
        //      result = 1
        //      while result <= x:
        //        result = 2 * result
        //      return result // 2

        //    e = other
        //    if self.__order:
        //      e = e % self.__order
        //    if e == 0:
        //      return INFINITY
        //    if self == INFINITY:
        //      return INFINITY
        //    assert e > 0

        //    # From X9.62 D.3.2:

        //    e3 = 3 * e
        //    negative_self = Point(self.__curve, self.__x, -self.__y, self.__order)
        //    i = leftmost_bit(e3) // 2
        //    result = self
        //    # print_("Multiplying %s by %d (e3 = %d):" % (self, other, e3))
        //    while i > 1:
        //      result = result.double()
        //      if (e3 & i) != 0 and(e & i) == 0:
        //        result = result + self
        //      if (e3 & i) == 0 and(e & i) != 0:
        //        result = result + negative_self
        //# print_(". . . i = %d, result = %s" % ( i, result ))
        //      i = i // 2

        //    return result


    }
}