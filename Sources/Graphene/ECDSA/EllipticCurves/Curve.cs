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
        protected System.Numerics.BigInteger R { get; set; }


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

    }
}