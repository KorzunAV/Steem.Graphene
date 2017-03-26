//import logging

//from piston.instance import shared_steem_instance
//from pistonbase import transactions, operations
//from pistonbase.account import PrivateKey
//from pistonbase.operations import Operation
//from pistonbase.signedtransactions import Signed_Transaction

//from .account import Account
//from .exceptions import (
//    InsufficientAuthorityError,
//    MissingKeyError,
//    InvalidKeyFormat
//)
//log = logging.getLogger(__name__)

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphene.Core
{
    /// <summary>
    /// This class simplifies the creation of transactions by adding operations and signers.
    /// </summary>
    public class TransactionBuilder
    {
        public Steem Steem { get; set; }
        public List<Operation> ops { get; set; }
        public List<string> wifs { get; set; }
        public Transaction Transaction { get; set; }


        public TransactionBuilder(Steem steem)  //def __init__(self, tx={ }, steem_instance=None):
        {
            Steem = steem;                  //self.steem = steem_instance or shared_steem_instance()
            ops = new List<Operation>();    //self.op = []
            wifs = new List<string>();      //self.wifs = []
            //if not isinstance(tx, dict):
            //  raise ValueError("Invalid TransactionBuilder Format")
            //super(TransactionBuilder, self).__init__(tx)
        }


        public void AppendOps(Operation op)//def appendOps(self, ops):
        {
            //if isinstance(ops, list):
            //    for op in ops:
            //        self.op.append(op)
            //else:
            //    self.op.append(ops)
            //self.constructTx()
            ops.Add(op);
            ConstructTx();
        }

        public void AppendSigner(string accountName, Permission permission) //def appendSigner(self, account, permission):
        {
            //account = Account(account, steem_instance=self.steem)
            var account = new Account(accountName, Steem);
            //if permission == "active":
            //    wif = self.steem.wallet.getActiveKeyForAccount(account["name"])
            //elif permission == "posting":
            //    wif = self.steem.wallet.getPostingKeyForAccount(account["name"])
            //elif permission == "owner":
            //    wif = self.steem.wallet.getOwnerKeyForAccount(account["name"])
            //else:
            //    raise ValueError("Invalid permission")
            //self.wifs.append(wif)
        }

        //    def appendWif(self, wif):
        //        if wif:
        //            try:
        //                PrivateKey(wif)
        //                self.wifs.append(wif)
        //            except:
        //                raise InvalidKeyFormat


        public void ConstructTx()//def constructTx(self):
        {
            //if isinstance(self.op, list):
            //    ops = [Operation(o) for o in self.op]
            //else:
            //    ops = [Operation(self.op)]
            //expiration = transactions.formatTimeFromNow(self.steem.expiration)
            var expiration = Transaction.formatTimeFromNow(Steem.Expiration);
            //ref_block_num, ref_block_prefix = transactions.getBlockParams(self.steem.rpc)
            var rez = Transaction.getBlockParams(Steem.RPC);
            var ref_block_num = rez[0];
            var ref_block_prefix = rez[1];
            var st = SignedTransaction(new[] { ref_block_num, ref_block_prefix, expiration, ops });
            //tx = Signed_Transaction(ref_block_num= ref_block_num, ref_block_prefix= ref_block_prefix, expiration= expiration, operations= ops)
            //super(TransactionBuilder, self).__init__(tx.json())

            //> сетим TransactionBuilder(st.json())
            //{ 'operations': [['vote', {'permlink': '', 'voter': 'joseph.kalu', 'author': 'cat1', 'weight': 10000}]], 'expiration': '2017-03-26T11:16:01', 'extensions': [], 'ref_block_num': 24267, 'ref_block_prefix': 2066969480, 'signatures': []
        }

        /// <summary>
        /// Sign a provided transaction witht he provided key(s)
        ///
        ///:param dict tx: The transaction to be signed and returned
        ///: param string wifs: One or many wif keys to use for signing
        ///     a transaction.If not present, the keys will be loaded
        ///
        ///
        ///     from the wallet as defined in "missing_signatures" key
        ///
        ///
        ///     of the transactions.
        /// </summary>
        public void Sign() //def sign(self):
        {
            //# We need to set the default prefix, otherwise pubkeys are
            //# presented wrongly!
            //if self.steem.rpc:
            //    operations.default_prefix = self.steem.rpc.chain_params["prefix"]
            //elif "blockchain" in self:
            //    operations.default_prefix = self["blockchain"]["prefix"]
            //
            //try:
            //    signedtx = Signed_Transaction(**self.json())
            //except:
            //    raise ValueError("Invalid TransactionBuilder Format")
            //
            //if not any(self.wifs):
            //    raise MissingKeyError
            //
            //signedtx.sign(self.wifs, chain = self.steem.rpc.chain_params)
            //self["signatures"].extend(signedtx.json().get("signatures"))

        }


        //    def sign(self):
        //        """ Sign a provided transaction witht he provided key(s)

        //            :param dict tx: The transaction to be signed and returned
        //            :param string wifs: One or many wif keys to use for signing
        //                a transaction.If not present, the keys will be loaded
        //               from the wallet as defined in "missing_signatures" key
        //               of the transactions.
        //        """

        //        # We need to set the default prefix, otherwise pubkeys are
        //        # presented wrongly!
        //        if self.steem.rpc:

        //           operations.default_prefix = self.steem.rpc.chain_params["prefix"]

        //       elif "blockchain" in self:

        //           operations.default_prefix = self["blockchain"]["prefix"]

        //        try:

        //           signedtx = Signed_Transaction(**self.json())

        //       except:

        //           raise ValueError("Invalid TransactionBuilder Format")

        //        if not any(self.wifs):
        //            raise MissingKeyError

        //        signedtx.sign(self.wifs, chain=self.steem.rpc.chain_params)
        //        self["signatures"].extend(signedtx.json().get("signatures"))

        //    def broadcast(self):
        //        """ Broadcast a transaction to the Steem network

        //            :param tx tx: Signed transaction to broadcast
        //        """
        //        if self.steem.nobroadcast:
        //            log.warning("Not broadcasting anything!")
        //            return self

        //        try:
        //            if not self.steem.rpc.verify_authority(self.json()):
        //                raise InsufficientAuthorityError
        //        except Exception as e:
        //            raise e

        //        try:
        //            self.steem.rpc.broadcast_transaction(self.json(), api="network_broadcast")
        //        except Exception as e:
        //            raise e

        //        return self

        //    def addSigningInformation(self, account, permission):
        //        """ This is a private method that adds side information to a
        //            unsigned/partial transaction in order to simplify later
        //            signing(e.g. for multisig or coldstorage)
        //        """
        //        accountObj = Account(account, steem_instance= self.steem)
        //        authority = accountObj[permission]
        //# We add a required_authorities to be able to identify
        //# how to sign later. This is an array, because we
        //# may later want to allow multiple operations per tx
        //        self.update({
        //    "required_authorities": {
        //    account: authority
        //        }
        //})
        //        for account_auth in authority["account_auths"]:
        //            account_auth_account = Account(account_auth[0], steem_instance= self.steem)
        //            self["required_authorities"].update({
        //    account_auth[0]: account_auth_account.get(permission)
        //            })

        //        # Try to resolve required signatures for offline signing
        //        self["missing_signatures"] = [
        //            x[0] for x in authority["key_auths"]
        //        ]
        //        # Add one recursion of keys from account_auths:
        //        for account_auth in authority["account_auths"]:
        //            account_auth_account = Account(account_auth[0], steem_instance= self.steem)
        //            self["missing_signatures"].extend(
        //                [x[0] for x in account_auth_account[permission]["key_auths"]]
        //            )
        //        self["blockchain"] = self.steem.rpc.chain_params

        //    def json(self):
        //        return dict(self)

        //    def appendMissingSignatures(self, wifs):
        //        missing_signatures = self.get("missing_signatures", [])
        //        for pub in missing_signatures:
        //            wif = self.steem.wallet.getPrivateKeyForPublicKey(pub)
        //            if wif:
        //                self.appendWif(wif)
    }
}