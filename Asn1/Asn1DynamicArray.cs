using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Asn1
{
    class Asn1DynamicArray : Asn1CompositeNode
    {
        public const string NODE_NAME = "Dynamic Length Array";

        readonly private Asn1UniversalNodeType _type;

        public static Asn1DynamicArray ReadFrom(Asn1UniversalNodeType type, Stream stream)
        {
            Asn1DynamicArray array = new Asn1DynamicArray(type);
            Asn1Node node;
            while ((node = Asn1Node.ReadNode(stream)) != null)
            {
                array.Nodes.Add(node);
            }
            return array;
        }

        private Asn1DynamicArray(Asn1UniversalNodeType type)
        {
            _type = type;
        }


        public override Asn1UniversalNodeType NodeType => _type;

        protected override XElement ToXElementCore()
        {
            return new XElement(NODE_NAME);
        }
    }
}
