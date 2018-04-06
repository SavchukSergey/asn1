using System.IO;
using NUnit.Framework;

namespace Asn1.Tests {
    [TestFixture]
    [TestOf(typeof(Asn1Null))]
    public class Asn1NullTests : BaseTest {

        private static readonly byte[] _etalon = { 0x05, 0x00 };

        [Test]
        public void ReadTest() {
            var node = Asn1Node.ReadNode(new MemoryStream(_etalon));
            var typed = node as Asn1Null;
            Assert.IsNotNull(typed);
        }

        [Test]
        public void WriteTest() {
            var node = new Asn1Null();
            var data = node.GetBytes();
            AreEqual(_etalon, data);
        }
    }
}
