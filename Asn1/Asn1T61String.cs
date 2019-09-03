using System.IO;
using System.Text;
using System.Xml.Linq;

namespace Asn1 {
    public class Asn1T61String : Asn1Node {

        public const string NODE_NAME = "T61";

        public string Value { get; set; }

        public Asn1T61String() {
        }

        public Asn1T61String(string value) {
            Value = value;
        }

        public static Asn1T61String ReadFrom(Stream stream) {
            var data = new byte[stream.Length];
            stream.Read(data, 0, data.Length);
            // Similar to BouncyCastle, we use the UTF-8 encoding as T.61 should be deprecated by now but is still in use
            return new Asn1T61String { Value = Encoding.UTF8.GetString(data) };
        }

        public override Asn1UniversalNodeType NodeType => Asn1UniversalNodeType.T61String;

        public override Asn1TagForm TagForm => Asn1TagForm.Primitive;

        protected override XElement ToXElementCore() {
            return new XElement(NODE_NAME, Value);
        }

        protected override byte[] GetBytesCore() {
            return Encoding.UTF8.GetBytes(Value);
        }

        public new static Asn1T61String Parse(XElement xNode) {
            var res = new Asn1T61String { Value = xNode.Value.Trim() };
            //todo should it be trimmed?
            return res;
        }
    }
}