using System.Numerics;
using ECDSA.Helpers;

namespace ECDSA.EllipticCurves
{
    public class SECP256k1 : CurveBase
    {
        /// <summary>
        /// https://github.com/warner/python-ecdsa/blob/6c8a70eb615d4cb85e37e8e054db910e8c62a5c6/src/ecdsa/ecdsa.py
        /// </summary>
        public SECP256k1()
        {
            //self.name = "SECP256k1";
            //self.openssl_name = "secp256k1"  # maybe None
            //self.curve = ecdsa.curve_secp256k1
            //self.generator = ecdsa.generator_secp256k1
            ////self.order = generator.order()
            ////self.baselen = orderlen(self.order)
            ////self.verifying_key_length = 2 * self.baselen
            ////self.signature_length = 2 * self.baselen
            //self.oid = (1, 3, 132, 0, 10)
            ////self.encoded_oid = der.encode_oid(*oid)


            //0x7fffffffffffffff7fffffffffffffff7fffffffffffffff7fffffffffffffff;
            var tsss = new System.Numerics.BigInteger(new byte[]
            {
                0x7f, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0x7f, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0x7f,
                0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0x7f, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff
            });

            //0x0000000000000000000000000000000000000000000000000000000000000000; 
            A = new System.Numerics.BigInteger(new byte[]
            {
                0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00
            });

            //0x0000000000000000000000000000000000000000000000000000000000000007; 
            B = new System.Numerics.BigInteger(new byte[]
            {
                0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x07
            });

            //0xfffffffffffffffffffffffffffffffffffffffffffffffffffffffefffffc2f; 
            P = new System.Numerics.BigInteger(new byte[]
            {
                0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff,
                0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xfe, 0xff, 0xff, 0xfc, 0x2f
            });

            //0x79be667ef9dcbbac55a06295ce870b07029bfcdb2dce28d959f2815b16f81798; 
            Gx = new System.Numerics.BigInteger(new byte[]
            {
                0x79, 0xbe, 0x66, 0x7e, 0xf9, 0xdc, 0xbb, 0xac, 0x55, 0xa0, 0x62, 0x95, 0xce, 0x87, 0x0b, 0x07, 0x02,
                0x9b, 0xfc, 0xdb, 0x2d, 0xce, 0x28, 0xd9, 0x59, 0xf2, 0x81, 0x5b, 0x16, 0xf8, 0x17, 0x98
            });

            //0x483ada7726a3c4655da4fbfc0e1108a8fd17b448a68554199c47d08ffb10d4b8; 
            Gy = new System.Numerics.BigInteger(new byte[]
            {
                0x48, 0x3a, 0xda, 0x77, 0x26, 0xa3, 0xc4, 0x65, 0x5d, 0xa4, 0xfb, 0xfc, 0x0e, 0x11, 0x08, 0xa8, 0xfd,
                0x17, 0xb4, 0x48, 0xa6, 0x85, 0x54, 0x19, 0x9c, 0x47, 0xd0, 0x8f, 0xfb, 0x10, 0xd4, 0xb8
            });

            //0xfffffffffffffffffffffffffffffffebaaedce6af48a03bbfd25e8cd0364141; 
            R = new System.Numerics.BigInteger(new byte[]
            {
                0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xfe, 0xba,
                0xae, 0xdc, 0xe6, 0xaf, 0x48, 0xa0, 0x3b, 0xbf, 0xd2, 0x5e, 0x8c, 0xd0, 0x36, 0x41, 0x41
            });
        }


        public void CompressedPubKey(string wif)
        {
            var curv = new SECP256k1();
            var secret = ConverterHelper.HexStringToByteArray(wif);
            var order = R;
            var p = curv * string_to_number(secret);


            //2    p = ecdsa.SigningKey.from_string(secret, curve = ecdsa.SECP256k1).verifying_key.pubkey.point
            //2    x_str = ecdsa.util.number_to_string(p.x(), order)
            //2    y_str = ecdsa.util.number_to_string(p.y(), order)
            //2    compressed = hexlify(bytes(chr(2 + (p.y() & 1)), 'ascii') + x_str).decode('ascii')
            //2    uncompressed = hexlify(bytes(chr(4), 'ascii') + x_str + y_str).decode('ascii')
            //2    return ([compressed, uncompressed])
        }


        public object GetPoint(BigInteger other)
        {


            //        def __mul__(self, other):
            //    """Multiply a point by an integer."""

            //    def leftmost_bit(x):
            //      assert x > 0
            //      result = 1
            //      while result <= x:
            //        result = 2 * result
            //      return result // 2

            var e = other;
            //    if self.__order:
            //      e = e % self.__order
            e = e % R;

            if (e == 0)
            {
                return BigInteger.m
            }
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
}