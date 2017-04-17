//using System;
//using System.Collections.Generic;
//using System.Globalization;
//using System.Linq;
//using System.Net.Http;
//using System.Security.Cryptography;
//using System.Text;
//using System.Threading.Tasks;

using System.Security.Cryptography;
using ECDSA.Helpers;
using NUnit.Framework;
//using Graphene.Core;

namespace Tests
{
    [TestFixture]
    public class TransactionBuilderTest
    {
        
        [Test]
        public void HexStringToByteArrayTest()
        {
            var one_time_private = ConverterHelper.HexStringToByteArray("5cea26accf0ff2fce735c7e75d3c203213404af600ba848aa42e147f9718c584");
            SHA1 sha = new SHA1CryptoServiceProvider();
            var sha1Hash = sha.ComputeHash(one_time_private);

            0xfffffffffffffffffffffffffffffffebaaedce6af48a03bbfd25e8cd0364141

            //Assert.IsTrue(array.Length == key.Length);

            //for (var i = 0; i < key.Length; i++)
            //{
            //    Assert.IsTrue(array[i] == key[i]);
            //}
        }



        //[Test]
        //public void Test()
        //{
        //    //var to_public = new byte[]
        //    //{0xST, 0xM7, 0xvb, 0xxt, 0xK1, 0xWa, 0xZq, 0xXs, 0xiC, 0xHP, 0xcj, 0xVF, 0xBe, 0xwV, 0xj8, 0xHF, 0xRd, 0x5Z, 0x5X, 0xZD, 0xpN, 0x6P, 0xvb, 0x2d, 0xZc, 0xMq, 0xK};

        //    var one_time_private = ConverterHelper.HexStringToByteArray("8fdfdde486f696fd7c6313325e14d3ff0c34b6e2c390d1944cbfe150f4457168");

        //    SHA256 mySHA256 = SHA256Managed.Create();
        //    var hashValue = mySHA256.ComputeHash(one_time_private);


        //    //var sha256 = System.Security.Cryptography.SHA256.Create();
        //    //sha256.

        //    //var t = System.Security.Cryptography.ECDsaCng.Create();
        //}

        //[Test]
        //public void VoteTest()
        //{
        //    //

        //    /*op = operations.Vote(
        //    **{"voter": voter,
        //       "author": post_author,
        //       "permlink": post_permlink,
        //       "weight": int(weight * STEEMIT_1_PERCENT)}*/


        //    var accountName = "josephkalu";

        //    var steem = new Steem();
        //    var ops = new List<Operation>
        //    {
        //        new Operation()
        //    };
        //    steem.FinalizeOp(ops, accountName, Permission.Posting);

        //}



    }
}
