using System.IO;
using NUnit.Framework;

namespace Asn1.Tests {
    [TestFixture]
    [TestOf(typeof(Asn1Integer))]
    public class Asn1IntegerTests : BaseTest {

        private static readonly byte[] _etalon = { 0x02, 0x01, 0x00 };

        [Test]
        public void ReadTest() {
            var node = Asn1Node.ReadNode(new MemoryStream(_etalon));
            var typed = node as Asn1Integer;
            Assert.IsNotNull(typed);
            Assert.AreEqual(new byte[] { 0 }, typed.Value);
        }

        [Test]
        public void WriteTest() {
            var node = new Asn1Integer(0);
            var data = node.GetBytes();
            AreEqual(_etalon, data);
        }
    }
}
