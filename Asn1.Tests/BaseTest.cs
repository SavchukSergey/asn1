using System;
using System.IO;
using NUnit.Framework;

namespace Asn1.Tests {
    public abstract class BaseTest {

        public static void AreEqual(byte[] expected, byte[] actual) {
            Assert.AreEqual(expected.Length, actual.Length);
            for (var i = 0; i < expected.Length; i++) {
                Assert.AreEqual(expected[i], actual[i]);
            }
        }

        protected byte[] GetEmbeddedBytes(string name) {
            var stream = GetEmbeddedStream(name);
            var bytes = new byte[stream.Length];
            return bytes;
        }

        protected Stream GetEmbeddedStream(string name) {
            var type = GetType();
            var assembly = type.Assembly;
            var stream = assembly.GetManifestResourceStream($"{type.Namespace}.{name}");
            if (stream == null) throw new Exception($"Resource is not found");
            return stream;
        }

    }
}
