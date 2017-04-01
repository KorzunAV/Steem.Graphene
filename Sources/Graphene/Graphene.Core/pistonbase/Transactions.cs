//from collections import OrderedDict
//from binascii import hexlify, unhexlify
//from calendar import timegm
//from datetime import datetime
//import json
//import struct
//import time

//from pistonbase.account import PublicKey
//from.signedtransactions import Signed_Transaction as GrapheneSigned_Transaction

//# Import all operations so they can be loaded from this module
//from .operations import (
//    Operation, Permission, Memo, Vote, Comment, Amount,
//    Exchange_rate, Witness_props, Account_create, Account_update,
//    Transfer, Transfer_to_vesting, Withdraw_vesting, Limit_order_create,
//    Limit_order_cancel, Set_withdraw_vesting_route, Convert, Feed_publish,
//    Witness_update, Transfer_to_savings, Transfer_from_savings,
//    Cancel_transfer_from_savings, Account_witness_vote, Custom_json,
//)
//from.chains import known_chains

//timeformat = '%Y-%m-%dT%H:%M:%S%Z'

//chain = "STEEM"
//# chain = "TEST"

using System;
using System.IO;
using System.Net;

namespace Graphene.Core
{
    public class Transactions
    {
        private const string timeformat = "yyyy-MM-ddThh:mm:ss";



        //class Signed_Transaction(GrapheneSigned_Transaction):
        //    """ Overwrite default chain:
        //    """
        //    def __init__(self, * args, ** kwargs):
        //        super(Signed_Transaction, self).__init__(*args, ** kwargs)

        //    def sign(self, wifkeys, chain= chain):
        //        return super(Signed_Transaction, self).sign(wifkeys, chain)

        //    def verify(self, pubkey, chain= chain):
        //        return super(Signed_Transaction, self).verify(pubkey, chain)


        /// <summary>
        /// Auxiliary method to obtain ``ref_block_num`` and
        /// ``ref_block_prefix``. Requires a websocket connection to a
        /// witness node!
        /// </summary>
        /// <param name="rpc"></param>
        /// <returns></returns>
        public string[] getBlockParams(SteemNodeRPC rpc) //def getBlockParams(ws):
        {
            //    dynBCParams = ws.get_dynamic_global_properties()
            //    ref_block_num = dynBCParams["head_block_number"] & 0xFFFF
            //    ref_block_prefix = struct.unpack_from("<I", unhexlify(dynBCParams["head_block_id"]), 4)[0]
            //    return ref_block_num, ref_block_prefix

            var dynBCParams = rpc.get_dynamic_global_properties();
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

        /// <summary>
        /// Properly Format Time that is `x` seconds in the future
        ///:param int secs: Seconds to go in the future(`x>0`) or the past(`x<0`)
        ///:return: Properly formated time for Graphene(`%Y-%m-%dT%H:%M:%S`)
        ///:rtype: str
        /// </summary>
        /// <param name="expiration"></param>
        /// <returns></returns>
        public string formatTimeFromNow(int expiration)//def formatTimeFromNow(secs= 0):
        {
            //    return datetime.utcfromtimestamp(time.time() + int(secs)).strftime(timeformat)
            return DateTime.UtcNow.AddSeconds(expiration).ToString(timeformat);
        }
    }
}