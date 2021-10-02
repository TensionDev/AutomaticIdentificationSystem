using System;
using System.Collections.Generic;
using TensionDev.Maritime.AIS;
using Xunit;

namespace XUnitTestProjectAIS
{
    public class UnitTestAISMessage24
    {
        [Fact]
        public void AIS24ADecoding()
        {
            IList<String> sentences = new List<String>()
            {
                "!AIVDO,1,1,,B,H1c2;qA@PU>0U>060<h5=>0:1Dp,2*7D"
            };

            AISMessage aisMessage = AISMessage.DecodeSentences(sentences);
            AISMessage24 aisMessage24 = aisMessage as AISMessage24;

            Assert.NotNull(aisMessage);
            Assert.NotNull(aisMessage24);
            Assert.Equal(24, aisMessage24.MessageId);
            Assert.Equal(0, aisMessage24.RepeatIndicator);
            Assert.Equal("112233445", aisMessage24.UserId);
            Assert.Equal(AISMessage24.PartNumberEnum.PartA, aisMessage24.PartNumber);
            Assert.Equal("THIS IS A CLASS B UN", aisMessage24.Name);
        }

        [Fact]
        public void AIS24BDecoding()
        {
            IList<String> sentences = new List<String>()
            {
                "!AIVDO,1,1,,B,H1c2;qDTijklmno31<<C970`43<1,0*28"
            };

            AISMessage aisMessage = AISMessage.DecodeSentences(sentences);
            AISMessage24 aisMessage24 = aisMessage as AISMessage24;

            Assert.NotNull(aisMessage);
            Assert.NotNull(aisMessage24);
            Assert.Equal(24, aisMessage24.MessageId);
            Assert.Equal(0, aisMessage24.RepeatIndicator);
            Assert.Equal("112233445", aisMessage24.UserId);
            Assert.Equal(AISMessage24.PartNumberEnum.PartB, aisMessage24.PartNumber);
            Assert.Equal(36, aisMessage24.TypeOfShipAndCargoType);
            Assert.Equal("1234567", aisMessage24.VendorId);
            Assert.Equal("CALLSIG", aisMessage24.CallSign);
            Assert.Equal(5, aisMessage24.DimensionToBow);
            Assert.Equal(4, aisMessage24.DimensionToStern);
            Assert.Equal(3, aisMessage24.DimensionToPort);
            Assert.Equal(12, aisMessage24.DimensionToStarboard);
        }
    }
}
