
//class VerifyingKey :
//    def __init__(self, _error__please_use_generate=None):
//        if not _error__please_use_generate:
//            raise TypeError("Please use SigningKey.generate() to construct me")

//    @classmethod
//    def from_public_point(klass, point, curve=NIST192p, hashfunc=sha1):
//        self = klass(_error__please_use_generate=True)
//        self.curve = curve
//        self.default_hashfunc = hashfunc
//        self.pubkey = ecdsa.Public_key(curve.generator, point)
//        self.pubkey.order = curve.order
//        return self

//    @classmethod
//    def from_string(klass, string, curve=NIST192p, hashfunc=sha1,
//                    validate_point=True):
//        order = curve.order
//        assert (len(string) == curve.verifying_key_length), \
//               (len(string), curve.verifying_key_length)
//        xs = string[:curve.baselen]
//ys = string[curve.baselen:]
//assert len(xs) == curve.baselen, (len(xs), curve.baselen)
//        assert len(ys) == curve.baselen, (len(ys), curve.baselen)
//        x = string_to_number(xs)
//        y = string_to_number(ys)
//        if validate_point:
//            assert ecdsa.point_is_valid(curve.generator, x, y)
//        from.import ellipticcurve
//        point = ellipticcurve.Point(curve.curve, x, y, order)
//        return klass.from_public_point(point, curve, hashfunc)

//    @classmethod
//    def from_pem(klass, string):
//        return klass.from_der(der.unpem(string))

//    @classmethod
//    def from_der(klass, string):
//        # [[oid_ecPublicKey,oid_curve], point_str_bitstring]
//        s1, empty = der.remove_sequence(string)
//        if empty != b(""):
//            raise der.UnexpectedDER("trailing junk after DER pubkey: %s" %
//                                    binascii.hexlify(empty))
//        s2, point_str_bitstring = der.remove_sequence(s1)
//        # s2 = oid_ecPublicKey,oid_curve
//        oid_pk, rest = der.remove_object(s2)
//        oid_curve, empty = der.remove_object(rest)
//        if empty != b(""):
//            raise der.UnexpectedDER("trailing junk after DER pubkey objects: %s" %
//                                    binascii.hexlify(empty))
//        assert oid_pk == oid_ecPublicKey, (oid_pk, oid_ecPublicKey)
//        curve = find_curve(oid_curve)
//        point_str, empty = der.remove_bitstring(point_str_bitstring)
//        if empty != b(""):
//            raise der.UnexpectedDER("trailing junk after pubkey pointstring: %s" %
//                                    binascii.hexlify(empty))
//        assert point_str.startswith(b("\x00\x04"))
//        return klass.from_string(point_str[2:], curve)

//    def to_string(self):
//        # VerifyingKey.from_string(vk.to_string()) == vk as long as the
//        # curves are the same: the curve itself is not included in the
//        # serialized form
//        order = self.pubkey.order
//        x_str = number_to_string(self.pubkey.point.x(), order)
//        y_str = number_to_string(self.pubkey.point.y(), order)
//        return x_str + y_str

//    def to_pem(self):
//        return der.topem(self.to_der(), "PUBLIC KEY")

//    def to_der(self):
//        order = self.pubkey.order
//        x_str = number_to_string(self.pubkey.point.x(), order)
//        y_str = number_to_string(self.pubkey.point.y(), order)
//        point_str = b("\x00\x04") + x_str + y_str
//        return der.encode_sequence(der.encode_sequence(encoded_oid_ecPublicKey,
//                                                       self.curve.encoded_oid),
//                                   der.encode_bitstring(point_str))

//    def verify(self, signature, data, hashfunc= None, sigdecode= sigdecode_string):
//        hashfunc = hashfunc or self.default_hashfunc
//        digest = hashfunc(data).digest()
//        return self.verify_digest(signature, digest, sigdecode)

//    def verify_digest(self, signature, digest, sigdecode= sigdecode_string):
//        if len(digest) > self.curve.baselen:
//            raise BadDigestError("this curve (%s) is too short "
//                                 "for your digest (%d)" % (self.curve.name,
//                                                           8 * len(digest)))
//        number = string_to_number(digest)
//        r, s = sigdecode(signature, self.pubkey.order)
//        sig = ecdsa.Signature(r, s)
//        if self.pubkey.verifies(number, sig):
//            return True
//        raise BadSignatureError