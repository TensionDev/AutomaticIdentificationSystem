using System;
using System.Collections.Generic;
using TensionDev.Maritime.AIS;
using Xunit;

namespace XUnitTestProjectAIS
{
    public class UnitTestAISMessage02
    {
        private const Int32 POSITIONAL_PRECISION = 5;

        [Fact]
        public void AIS02Decoding01()
        {
            IList<String> sentences = new List<String>()
            {
                "!AIVDM,1,1,,A,25Mw@DP000qR9bFA:6KI0AV@00S3,0*0A"
            };

            AISMessage aisMessage = AISMessage.DecodeSentences(sentences);
            AISMessage02 aisMessage02 = aisMessage as AISMessage02;

            Assert.NotNull(aisMessage);
            Assert.NotNull(aisMessage02);
            Assert.Equal(AISMessage.SentenceFormatterEnum.VDM, aisMessage02.SentenceFormatter);
            Assert.Equal(2, aisMessage02.MessageId);
            Assert.Equal(0, aisMessage02.RepeatIndicator);
            Assert.Equal("366989394", aisMessage02.UserId);
            Assert.Equal(AISMessage02.NavigationalStatusEnum.UnderWayUsingEngine, aisMessage02.NavigationalStatus);
            Assert.Equal(0, aisMessage02.RateOfTurnDegreesPerMinute);
            Assert.True(aisMessage02.TurnIndicatorAvailable);
            Assert.True(aisMessage02.TurnInformationAvailable);
            Assert.Equal(0, aisMessage02.SpeedOverGroundKnots);
            Assert.True(aisMessage02.SpeedOverGroundAvailable);
            Assert.True(aisMessage02.PositionAccuracy);
            Assert.Equal(-90.4067M, aisMessage02.LongitudeDecimalDegrees, POSITIONAL_PRECISION);
            Assert.True(aisMessage02.LongitudeAvailable);
            Assert.Equal(29.9854616666667M, aisMessage02.LatitudeDecimalDegrees, POSITIONAL_PRECISION);
            Assert.True(aisMessage02.LatitudeAvailable);
            Assert.Equal(230.5M, aisMessage02.CourseOverGroundDegrees);
            Assert.True(aisMessage02.CourseOverGroundAvailable);
            Assert.Equal(51, aisMessage02.TrueHeadingDegrees);
            Assert.True(aisMessage02.TrueHeadingAvailable);
            Assert.Equal(8, aisMessage02.Timestamp);
            Assert.Equal(AISMessage02.SpecialManoeuvreIndicatorEnum.NotAvailable, aisMessage02.SpecialManoeuvreIndicator);
            Assert.False(aisMessage02.RAIMFlag);
            Assert.Equal(SOTDMACommunicationState.SyncStateEnum.UTCDirect, aisMessage02.CommunicationState.SyncState);
            Assert.Equal(0, aisMessage02.CommunicationState.SlotTimeout);
        }

        [Fact]
        public void AIS02Decoding02()
        {
            IList<String> sentences = new List<String>()
            {
                "!AIVDM,1,1,,B,25Cjtd0Oj;Jp7ilG7=UkKBoB0<06,0*60"
            };

            AISMessage aisMessage = AISMessage.DecodeSentences(sentences);
            AISMessage02 aisMessage02 = aisMessage as AISMessage02;
            SOTDMACommunicationState communicationState = aisMessage02.CommunicationState;
            communicationState.GetReceivedStations(out UInt16 slotTimeout, out UInt16 receivedStations);

            Assert.NotNull(aisMessage);
            Assert.NotNull(aisMessage02);
            Assert.Equal(AISMessage.SentenceFormatterEnum.VDM, aisMessage02.SentenceFormatter);
            Assert.Equal(2, aisMessage02.MessageId);
            Assert.Equal(0, aisMessage02.RepeatIndicator);
            Assert.Equal("356302000", aisMessage02.UserId);
            Assert.Equal(AISMessage02.NavigationalStatusEnum.UnderWayUsingEngine, aisMessage02.NavigationalStatus);
            Assert.Equal(10, aisMessage02.RateOfTurnDegreesPerMinute);
            Assert.False(aisMessage02.TurnIndicatorAvailable);
            Assert.True(aisMessage02.TurnInformationAvailable);
            Assert.Equal(13.9M, aisMessage02.SpeedOverGroundKnots);
            Assert.True(aisMessage02.SpeedOverGroundAvailable);
            Assert.False(aisMessage02.PositionAccuracy);
            Assert.Equal(-71.626144M, aisMessage02.LongitudeDecimalDegrees, POSITIONAL_PRECISION);
            Assert.True(aisMessage02.LongitudeAvailable);
            Assert.Equal(40.39236M, aisMessage02.LatitudeDecimalDegrees, POSITIONAL_PRECISION);
            Assert.True(aisMessage02.LatitudeAvailable);
            Assert.Equal(87.7M, aisMessage02.CourseOverGroundDegrees);
            Assert.True(aisMessage02.CourseOverGroundAvailable);
            Assert.Equal(91, aisMessage02.TrueHeadingDegrees);
            Assert.True(aisMessage02.TrueHeadingAvailable);
            Assert.Equal(41, aisMessage02.Timestamp);
            Assert.Equal(AISMessage02.SpecialManoeuvreIndicatorEnum.NotAvailable, aisMessage02.SpecialManoeuvreIndicator);
            Assert.False(aisMessage02.RAIMFlag);
            Assert.Equal(SOTDMACommunicationState.SyncStateEnum.UTCDirect, aisMessage02.CommunicationState.SyncState);
            Assert.Equal(3, aisMessage02.CommunicationState.SlotTimeout);
            Assert.Equal(3, slotTimeout);
            Assert.Equal(6, receivedStations);
        }
    }
}
