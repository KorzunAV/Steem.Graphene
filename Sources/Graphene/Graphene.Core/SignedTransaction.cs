using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphene.Core
{
    public class SignedTransaction
    {
        public SignedTransaction()
        {
        }

        //https://github.com/xeroc/python-graphenelib/blob/98de98e219264d45fe04b3c28f3aabd1a9f58b71/graphenebase/signedtransactions.py#L225
        // Sign()

        /// <summary>
        /// Recover the public key from the the signature
        /// See http: //www.secg.org/download/aid-780/sec1-v2.pdf section 4.1.6 primarily
        /// </summary>
        public void RecoverPublicKey()
        {
            //https://github.com/warner/python-ecdsa
            //        curve = ecdsa.SECP256k1.curve
            //        G = ecdsa.SECP256k1.generator
            //        order = ecdsa.SECP256k1.order
            //        yp = (i % 2)
            //        r, s = ecdsa.util.sigdecode_string(signature, order)
            //        # 1.1
            //        x = r + (i // 2) * order
            //        # 1.3. This actually calculates for either effectively 02||X or 03||X depending on 'k' instead of always for 02||X as specified.
            //        # This substitutes for the lack of reversing R later on. -R actually is defined to be just flipping the y-coordinate in the elliptic curve.
            //        alpha = ((x * x * x) + (curve.a() * x) + curve.b()) % curve.p()
            //        beta = ecdsa.numbertheory.square_root_mod_prime(alpha, curve.p())
            //        y = beta if (beta - yp) % 2 == 0 else curve.p() - beta
            //        # 1.4 Constructor of Point is supposed to check if nR is at infinity.
            //        R = ecdsa.ellipticcurve.Point(curve, x, y, order)
            //        # 1.5 Compute e
            //        e = ecdsa.util.string_to_number(digest)
            //        # 1.6 Compute Q = r^-1(sR - eG)
            //        Q = ecdsa.numbertheory.inverse_mod(r, order) * (s * R + (-e % order) * G)
            //        # Not strictly necessary, but let's verify the message for paranoia's sake.
            //        if not ecdsa.VerifyingKey.from_public_point(Q, curve = ecdsa.SECP256k1).verify_digest(signature, digest, sigdecode = ecdsa.util.sigdecode_string):
            //            return None
            //return ecdsa.VerifyingKey.from_public_point(Q, curve = ecdsa.SECP256k1)
        }
    }
}