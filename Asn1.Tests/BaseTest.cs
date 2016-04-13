using NUnit.Framework;

namespace Asn1.Tests {
    public abstract class BaseTest {

        public static void AreEqual(byte[] expected, byte[] actual) {
            Assert.AreEqual(expected.Length, actual.Length);
            for (var i = 0; i < expected.Length; i++) {
                Assert.AreEqual(expected[i], actual[i]);
            }
        }
    }
}
