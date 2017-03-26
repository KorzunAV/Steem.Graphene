using System;
using System.IO;
using System.Net;

namespace Graphene.Core
{
    public class Transaction
    {
        private const string timeformat = "yyyy-MM-ddThh:mm:ss";
        public string formatTimeFromNow(int expiration)
        {
            return DateTime.UtcNow.AddSeconds(expiration).ToString(timeformat);
        }

        public string[] getBlockParams(RPC RPC)
        {
            var dynBCParams = RPC.ExecuteRemoteCall("get_dynamic_global_properties");
            var ref_block_num = dynBCParams["head_block_number"];// & 0xFFFF;
            var ref_block_prefix = "2066969480"; //struct.unpack_from("<I", unhexlify(dynBCParams["head_block_id"]), 4)[0];

            return new[] { ref_block_num, ref_block_prefix };

            // (Pdb)p dynBCParams['head_block_number']
            //10510027
            //(Pdb) n
            //> / home / pmartynov /.virtualenvs / steemstagram / lib / python3.5 / site - packages / steembase / transactions.py(55)getBlockParams()
            //                  ->ref_block_prefix = struct.unpack_from("<I", unhexlify(dynBCParams["head_block_id"]), 4)[0]
            //(Pdb) p dynBCParams['head_block_id']
            //'00a05ecb8873337bbe4eb08687197f232efd8a22'
            //(Pdb) p unhexlify(dynBCParams['head_block_id'])
            //b'\x00\xa0^\xcb\x88s3{\xbeN\xb0\x86\x87\x19\x7f#.\xfd\x8a"'
            //(Pdb) p struct.unpack_from("<I", unhexlify(dynBCParams["head_block_id"]), 4)
            //(2066969480,)
            //(Pdb) p struct.unpack_from("<I", unhexlify(dynBCParams["head_block_id"]), 4)[0]
            //2066969480
        }


    }
}