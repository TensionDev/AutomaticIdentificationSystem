using System;
using System.Collections.Generic;
using TensionDev.Maritime.AIS;
using Xunit;

namespace XUnitTestProjectAIS
{
    public class UnitTestAISMessage24
    {
        [Fact]
        public void AIS24ADecoding01()
        {
            IList<String> sentences = new List<String>()
            {
                "!AIVDO,1,1,,B,H1c2;qA@PU>0U>060<h5=>0:1Dp,2*7D"
            };

            AISMessage aisMessage = AISMessage.DecodeSentences(sentences);
            AISMessage24 aisMessage24 = aisMessage as AISMessage24;

            Assert.NotNull(aisMessage);
            Assert.NotNull(aisMessage24);
            Assert.Equal(AISMessage.SentenceFormatterEnum.VDO, aisMessage24.SentenceFormatter);
            Assert.Equal(24, aisMessage24.MessageId);
            Assert.Equal(0, aisMessage24.RepeatIndicator);
            Assert.Equal("112233445", aisMessage24.UserId);
            Assert.Equal(AISMessage24.PartNumberEnum.PartA, aisMessage24.PartNumber);
            Assert.Equal("THIS IS A CLASS B UN", aisMessage24.Name);
        }

        [Fact]
        public void AIS24ADecoding02()
        {
            IList<String> sentences = new List<String>()
            {
                "!AIVDM,1,1,,A,H42O55i18tMET00000000000000,2*6D"
            };

            AISMessage aisMessage = AISMessage.DecodeSentences(sentences);
            AISMessage24 aisMessage24 = aisMessage as AISMessage24;

            Assert.NotNull(aisMessage);
            Assert.NotNull(aisMessage24);
            Assert.Equal(AISMessage.SentenceFormatterEnum.VDM, aisMessage24.SentenceFormatter);
            Assert.Equal(24, aisMessage24.MessageId);
            Assert.Equal(0, aisMessage24.RepeatIndicator);
            Assert.Equal("271041815", aisMessage24.UserId);
            Assert.Equal(AISMessage24.PartNumberEnum.PartA, aisMessage24.PartNumber);
            Assert.Equal("PROGUY@@@@@@@@@@@@@@", aisMessage24.Name);
        }

        [Fact]
        public void AIS24BDecoding01()
        {
            IList<String> sentences = new List<String>()
            {
                "!AIVDO,1,1,,B,H1c2;qDTijklmno31<<C970`43<1,0*28"
            };

            AISMessage aisMessage = AISMessage.DecodeSentences(sentences);
            AISMessage24 aisMessage24 = aisMessage as AISMessage24;

            Assert.NotNull(aisMessage);
            Assert.NotNull(aisMessage24);
            Assert.Equal(AISMessage.SentenceFormatterEnum.VDO, aisMessage24.SentenceFormatter);
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

        [Fact]
        public void AIS24BDecoding02()
        {
            IList<String> sentences = new List<String>()
            {
                "!AIVDM,1,1,,A,H42O55lti4hhhilD3nink000?050,0*40"
            };

            AISMessage aisMessage = AISMessage.DecodeSentences(sentences);
            AISMessage24 aisMessage24 = aisMessage as AISMessage24;

            Assert.NotNull(aisMessage);
            Assert.NotNull(aisMessage24);
            Assert.Equal(AISMessage.SentenceFormatterEnum.VDM, aisMessage24.SentenceFormatter);
            Assert.Equal(24, aisMessage24.MessageId);
            Assert.Equal(0, aisMessage24.RepeatIndicator);
            Assert.Equal("271041815", aisMessage24.UserId);
            Assert.Equal(AISMessage24.PartNumberEnum.PartB, aisMessage24.PartNumber);
            Assert.Equal(60, aisMessage24.TypeOfShipAndCargoType);
            Assert.Equal("1D00014", aisMessage24.VendorId);
            Assert.Equal("TC6163@", aisMessage24.CallSign);
            Assert.Equal(0, aisMessage24.DimensionToBow);
            Assert.Equal(15, aisMessage24.DimensionToStern);
            Assert.Equal(0, aisMessage24.DimensionToPort);
            Assert.Equal(5, aisMessage24.DimensionToStarboard);
        }
    }
}
