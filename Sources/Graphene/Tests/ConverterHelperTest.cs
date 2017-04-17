using ECDSA.Helpers;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class ConverterHelperTest
    {
        [Test]
        public void HexStringToByteArrayTest()
        {
            var teststring = "8fdfdde486f696fd7c6313325e14d3ff0c34b6e2c390d1944cbfe150f4457168";
            var key = new[]
            {
                '\x8f', '\xdf', '\xdd', '\xe4', '\x86', '\xf6', '\x96', '\xfd', '\x7c', '\x63', '\x13', '\x32', '\x5e',
                '\x14', '\xd3', '\xff', '\x0c', '\x34', '\xb6', '\xe2', '\xc3', '\x90', '\xd1', '\x94', '\x4c', '\xbf',
                '\xe1', '\x50', '\xf4', '\x45', '\x71', '\x68'
            };

            var array = ConverterHelper.HexStringToByteArray(teststring);

            Assert.IsTrue(array.Length == key.Length);

            for (var i = 0; i < key.Length; i++)
            {
                Assert.IsTrue(array[i] == key[i]);
            }
        }
    }
}
