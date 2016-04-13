using System.IO;
using System.Security.Cryptography.X509Certificates;
using NUnit.Framework;

namespace Asn1.Tests {
    [TestFixture]
    public class Asn1ObjectIdentifierTests : BaseTest {

        private static readonly byte[] _etalon = { 0x06, 0x03, 0x55, 0x04, 0x0a };

        [Test]
        public void ReadTest() {
            var node = Asn1Node.ReadNode(new MemoryStream(_etalon));
            var typed = node as Asn1ObjectIdentifier;
            Assert.IsNotNull(typed);
            Assert.AreEqual("2.5.4.10", typed.Value);
        }

        [Test]
        public void WriteTest() {
            var node = new Asn1ObjectIdentifier("2.5.4.10");
            var data = node.GetBytes();
            AreEqual(_etalon, data);
        }
    }
}
