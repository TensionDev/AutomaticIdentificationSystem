using System;
using System.Collections.Generic;
using TensionDev.Maritime.AIS;
using Xunit;

namespace XUnitTestProjectAIS
{
    public class UnitTestAISMessage13
    {
        [Fact]
        public void AIS13Decoding01()
        {
            IList<String> sentences = new List<String>()
            {
                "!AIVDM,1,1,,A,=39UOj0jFs9R,0*65"
            };

            AISMessage aisMessage = AISMessage.DecodeSentences(sentences);
            AISMessage13 aisMessage13 = aisMessage as AISMessage13;
            Boolean destination2 = aisMessage13.GetDestination2(out string destinationId2, out ushort sequenceNumber2);
            Boolean destination3 = aisMessage13.GetDestination3(out string destinationId3, out ushort sequenceNumber3);
            Boolean destination4 = aisMessage13.GetDestination4(out string destinationId4, out ushort sequenceNumber4);

            Assert.NotNull(aisMessage);
            Assert.NotNull(aisMessage13);
            Assert.Equal(13, aisMessage13.MessageId);
            Assert.Equal(0, aisMessage13.RepeatIndicator);
            Assert.Equal("211378120", aisMessage13.SourceId);
            Assert.Equal("211217560", aisMessage13.DestinationId1);
            Assert.Equal(2, aisMessage13.SequenceNumber1);
            Assert.False(destination2);
            Assert.False(destination3);
            Assert.False(destination4);
        }

        [Fact]
        public void AIS13Decoding02()
        {
            IList<String> sentences = new List<String>()
            {
                "!AIVDM,1,1,,A,=`0Pv1@:Ac8rbgPKHC9KdV<,2*27"
            };

            AISMessage aisMessage = AISMessage.DecodeSentences(sentences);
            AISMessage13 aisMessage13 = aisMessage as AISMessage13;
            Boolean destination2 = aisMessage13.GetDestination2(out string destinationId2, out ushort sequenceNumber2);
            Boolean destination3 = aisMessage13.GetDestination3(out string destinationId3, out ushort sequenceNumber3);
            Boolean destination4 = aisMessage13.GetDestination4(out string destinationId4, out ushort sequenceNumber4);

            Assert.NotNull(aisMessage);
            Assert.NotNull(aisMessage13);
            Assert.Equal(13, aisMessage13.MessageId);
            Assert.Equal(2, aisMessage13.RepeatIndicator);
            Assert.Equal("537411077", aisMessage13.SourceId);
            Assert.Equal("043101326", aisMessage13.DestinationId1);
            Assert.Equal(2, aisMessage13.SequenceNumber1);
            Assert.Equal("717096664", aisMessage13.DestinationId2);
            Assert.Equal(1, aisMessage13.SequenceNumber2);
            Assert.True(destination2);
            Assert.Equal("717096664", destinationId2);
            Assert.Equal(1, sequenceNumber2);
            Assert.Equal("211217560", aisMessage13.DestinationId3);
            Assert.Equal(3, aisMessage13.SequenceNumber3);
            Assert.True(destination3);
            Assert.Equal("211217560", destinationId3);
            Assert.Equal(3, sequenceNumber3);
            Assert.False(destination4);
        }
    }
}
