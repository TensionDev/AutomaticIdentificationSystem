using System;
using System.Collections.Generic;
using TensionDev.Maritime.AIS;
using Xunit;

namespace XUnitTestProjectAIS
{
    public class UnitTestAISMessage10
    {
        [Fact]
        public void AIS10Decoding01()
        {
            IList<String> sentences = new List<String>()
            {
                "!AIVDM,1,1,,B,:5MlU41GMK6@,0*6C"
            };

            AISMessage aisMessage = AISMessage.DecodeSentences(sentences);
            AISMessage10 aisMessage10 = aisMessage as AISMessage10;

            Assert.NotNull(aisMessage);
            Assert.NotNull(aisMessage10);
            Assert.Equal(10, aisMessage10.MessageId);
            Assert.Equal(0, aisMessage10.RepeatIndicator);
            Assert.Equal("366814480", aisMessage10.SourceId);
            Assert.Equal("366832740", aisMessage10.DestinationId);
        }

        [Fact]
        public void AIS10Decoding02()
        {
            IList<String> sentences = new List<String>()
            {
                "!AIVDM,1,1,,B,:6TMCD1GOS60,0*5B"
            };

            AISMessage aisMessage = AISMessage.DecodeSentences(sentences);
            AISMessage10 aisMessage10 = aisMessage as AISMessage10;

            Assert.NotNull(aisMessage);
            Assert.NotNull(aisMessage10);
            Assert.Equal(10, aisMessage10.MessageId);
            Assert.Equal(0, aisMessage10.RepeatIndicator);
            Assert.Equal("440882000", aisMessage10.SourceId);
            Assert.Equal("366972000", aisMessage10.DestinationId);
        }
    }
}
