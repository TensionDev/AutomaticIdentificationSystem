using System;
using System.Collections.Generic;
using TensionDev.Maritime.AIS;
using Xunit;

namespace XUnitTestProjectAIS
{
    public class UnitTestAISMessage
    {
        [Fact]
        public void AISDecodingNullList()
        {
            IList<String> sentences = null;

            Assert.Throws<ArgumentNullException>(() => { AISMessage.DecodeSentences(sentences); });
        }

        [Fact]
        public void AISDecodingEmptyList()
        {
            IList<String> sentences = new List<String>()
            {
            };

            Assert.Throws<ArgumentNullException>(() => { AISMessage.DecodeSentences(sentences); });
        }

        [Fact]
        public void AISDecodingInvalidSentenceIdentifier()
        {
            IList<String> sentences = new List<String>()
            {
                "!AIHDT,1,1,,B,25Cjtd0Oj;Jp7ilG7=UkKBoB0<06,0*60"
            };

            Assert.Throws<NotImplementedException>(() => { AISMessage.DecodeSentences(sentences); });
        }

        [Fact]
        public void AISDecodingInvalidSentenceCount()
        {
            IList<String> sentences = new List<String>()
            {
                "!AIVDM,2,1,,A,14eG;o@034o8sd<L9i:a;WF>062D,0*7D"
            };

            Assert.Throws<InvalidOperationException>(() => { AISMessage.DecodeSentences(sentences); });
        }

        [Fact]
        public void AISDecodingInvalidSquence()
        {
            IList<String> sentences = new List<String>()
            {
                "!AIVDM,2,1,7,A,58wt8Ui`g??r21`7S=:22058<v05Htp000000015>8OA;0sk,0*7B",
                "!AIVDM,2,2,3,A,eQ8823mDm3kP00000000000,2*5D"
            };

            Assert.Throws<InvalidOperationException>(() => { AISMessage.DecodeSentences(sentences); });
        }
    }
}
