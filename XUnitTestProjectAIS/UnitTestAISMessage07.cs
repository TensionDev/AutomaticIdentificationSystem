using System;
using System.Collections.Generic;
using TensionDev.Maritime.AIS;
using Xunit;

namespace XUnitTestProjectAIS
{
    public class UnitTestAISMessage07
    {
        [Fact]
        public void AIS07Decoding01()
        {
            IList<String> sentences = new List<String>()
            {
                "!AIVDM,1,1,,A,702R5`hwCjq8,0*6B"
            };

            AISMessage aisMessage = AISMessage.DecodeSentences(sentences);
            AISMessage07 aisMessage07 = aisMessage as AISMessage07;
            Boolean destination2 = aisMessage07.GetDestination2(out string destinationId2, out ushort sequenceNumber2);
            Boolean destination3 = aisMessage07.GetDestination3(out string destinationId3, out ushort sequenceNumber3);
            Boolean destination4 = aisMessage07.GetDestination4(out string destinationId4, out ushort sequenceNumber4);

            Assert.NotNull(aisMessage);
            Assert.NotNull(aisMessage07);
            Assert.Equal(7, aisMessage07.MessageId);
            Assert.Equal(0, aisMessage07.RepeatIndicator);
            Assert.Equal("002655651", aisMessage07.SourceId);
            Assert.Equal("265538450", aisMessage07.DestinationId1);
            Assert.Equal(0, aisMessage07.SequenceNumber1);
            Assert.False(destination2);
            Assert.False(destination3);
            Assert.False(destination4);
        }

        [Fact]
        public void AIS07Decoding02()
        {
            IList<String> sentences = new List<String>()
            {
                "!AIVDM,1,1,,A,7`0Pv1@:Ac8rbgPKH@,4*52"
            };

            AISMessage aisMessage = AISMessage.DecodeSentences(sentences);
            AISMessage07 aisMessage07 = aisMessage as AISMessage07;
            Boolean destination2 = aisMessage07.GetDestination2(out string destinationId2, out ushort sequenceNumber2);
            Boolean destination3 = aisMessage07.GetDestination3(out string destinationId3, out ushort sequenceNumber3);
            Boolean destination4 = aisMessage07.GetDestination4(out string destinationId4, out ushort sequenceNumber4);

            Assert.NotNull(aisMessage);
            Assert.NotNull(aisMessage07);
            Assert.Equal(7, aisMessage07.MessageId);
            Assert.Equal(2, aisMessage07.RepeatIndicator);
            Assert.Equal("537411077", aisMessage07.SourceId);
            Assert.Equal("043101326", aisMessage07.DestinationId1);
            Assert.Equal(2, aisMessage07.SequenceNumber1);
            Assert.Equal("717096664", aisMessage07.DestinationId2);
            Assert.Equal(1, aisMessage07.SequenceNumber2);
            Assert.True(destination2);
            Assert.Equal("717096664", destinationId2);
            Assert.Equal(1, sequenceNumber2);
            Assert.False(destination3);
            Assert.False(destination4);
        }
    }
}
