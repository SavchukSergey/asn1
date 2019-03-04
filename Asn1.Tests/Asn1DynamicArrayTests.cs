using System.IO;
using NUnit.Framework;

namespace Asn1.Tests {
    [TestFixture]
    [TestOf(typeof(Asn1Sequence))]
    public class Asn1DynamicArrayTests : BaseTest {

        private static readonly byte[] _etalon = { 0xa0, 0x80, 0x30, 0x0e, 0x06, 0x03, 0x55, 0x04, 0x0a, 0x13, 0x07, 0x54, 0x65, 0x73, 0x74, 0x4f, 0x72, 0x67, 0x00, 0x00 };

        [Test]
        public void ReadTest() {
            var node = Asn1Node.ReadNode(new MemoryStream(_etalon));
            var typed = node as Asn1DynamicArray;
            Assert.IsNotNull(typed);
            Assert.AreEqual(1, typed.Nodes.Count);
            Assert.AreEqual(2, typed.Nodes[0].Nodes.Count);
        }

        [Test]
        public void WriteTest() {
            var node = new Asn1DynamicArray(Asn1UniversalNodeType.Unknown);
            node.TagClass = Asn1TagClass.ContextDefined;
            var sequence = new Asn1Sequence();
            sequence.Nodes.Add(new Asn1ObjectIdentifier("2.5.4.10"));
            sequence.Nodes.Add(new Asn1PrintableString { Value = "TestOrg" });
            node.Nodes.Add(sequence);
            var data = node.GetBytes();
            AreEqual(_etalon, data);
        }
    }
}
