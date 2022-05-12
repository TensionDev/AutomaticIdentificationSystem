using System;
using System.Collections.Generic;
using TensionDev.Maritime.AIS;
using Xunit;

namespace XUnitTestProjectAIS
{
    public class UnitTestAISMessage01
    {
        private const Int32 POSITIONAL_PRECISION = 5;

        [Fact]
        public void AIS01Decoding01()
        {
            IList<String> sentences = new List<String>()
            {
                "!AIVDM,1,1,,A,14eG;o@034o8sd<L9i:a;WF>062D,0*7D"
            };
            TimeSpan excpectedUTC = new TimeSpan(16, 37, 0);

            AISMessage aisMessage = AISMessage.DecodeSentences(sentences);
            AISMessage01 aisMessage01 = aisMessage as AISMessage01;
            aisMessage01.CommunicationState.GetUTCHourAndMinute(out UInt16 slotTimeout, out TimeSpan utcTime);

            Assert.NotNull(aisMessage);
            Assert.NotNull(aisMessage01);
            Assert.Equal(AISMessage.SentenceFormatterEnum.VDM, aisMessage01.SentenceFormatter);
            Assert.Equal(1, aisMessage01.MessageId);
            Assert.Equal(0, aisMessage01.RepeatIndicator);
            Assert.Equal("316001245", aisMessage01.UserId);
            Assert.Equal(AISMessage01.NavigationalStatusEnum.UnderWayUsingEngine, aisMessage01.NavigationalStatus);
            Assert.Equal(0, aisMessage01.RateOfTurnDegreesPerMinute);
            Assert.True(aisMessage01.TurnIndicatorAvailable);
            Assert.True(aisMessage01.TurnInformationAvailable);
            Assert.Equal(19.6M, aisMessage01.SpeedOverGroundKnots);
            Assert.True(aisMessage01.SpeedOverGroundAvailable);
            Assert.True(aisMessage01.PositionAccuracy);
            Assert.Equal(-123.8777483M, aisMessage01.LongitudeDecimalDegrees, POSITIONAL_PRECISION);
            Assert.True(aisMessage01.LongitudeAvailable);
            Assert.Equal(49.2002833M, aisMessage01.LatitudeDecimalDegrees, POSITIONAL_PRECISION);
            Assert.True(aisMessage01.LatitudeAvailable);
            Assert.Equal(235.0M, aisMessage01.CourseOverGroundDegrees);
            Assert.True(aisMessage01.CourseOverGroundAvailable);
            Assert.Equal(235, aisMessage01.TrueHeadingDegrees);
            Assert.True(aisMessage01.TrueHeadingAvailable);
            Assert.Equal(7, aisMessage01.Timestamp);
            Assert.Equal(AISMessage01.SpecialManoeuvreIndicatorEnum.NotAvailable, aisMessage01.SpecialManoeuvreIndicator);
            Assert.False(aisMessage01.RAIMFlag);
            Assert.Equal(SOTDMACommunicationState.SyncStateEnum.UTCDirect, aisMessage01.CommunicationState.SyncState);
            Assert.Equal(1, aisMessage01.CommunicationState.SlotTimeout);
            Assert.Equal(1, slotTimeout);
            Assert.Equal(excpectedUTC, utcTime);
        }

        [Fact]
        public void AIS01Decoding02()
        {
            IList<String> sentences = new List<String>()
            {
                "!AIVDM,1,1,,A,15RTgt0PAso;90TKcjM8h6g208CQ,0*4A"
            };

            AISMessage aisMessage = AISMessage.DecodeSentences(sentences);
            AISMessage01 aisMessage01 = aisMessage as AISMessage01;
            aisMessage01.CommunicationState.GetSlotNumber(out UInt16 slotTimeout, out UInt16 slotNumber);

            Assert.NotNull(aisMessage);
            Assert.NotNull(aisMessage01);
            Assert.Equal(AISMessage.SentenceFormatterEnum.VDM, aisMessage01.SentenceFormatter);
            Assert.Equal(1, aisMessage01.MessageId);
            Assert.Equal(0, aisMessage01.RepeatIndicator);
            Assert.Equal("371798000", aisMessage01.UserId);
            Assert.Equal(AISMessage01.NavigationalStatusEnum.UnderWayUsingEngine, aisMessage01.NavigationalStatus);
            Assert.Equal(-10, aisMessage01.RateOfTurnDegreesPerMinute);
            Assert.False(aisMessage01.TurnIndicatorAvailable);
            Assert.True(aisMessage01.TurnInformationAvailable);
            Assert.Equal(12.3M, aisMessage01.SpeedOverGroundKnots);
            Assert.True(aisMessage01.SpeedOverGroundAvailable);
            Assert.True(aisMessage01.PositionAccuracy);
            Assert.Equal(-123.395383333M, aisMessage01.LongitudeDecimalDegrees, POSITIONAL_PRECISION);
            Assert.True(aisMessage01.LongitudeAvailable);
            Assert.Equal(48.38163333333M, aisMessage01.LatitudeDecimalDegrees, POSITIONAL_PRECISION);
            Assert.True(aisMessage01.LatitudeAvailable);
            Assert.Equal(224.0M, aisMessage01.CourseOverGroundDegrees);
            Assert.True(aisMessage01.CourseOverGroundAvailable);
            Assert.Equal(215, aisMessage01.TrueHeadingDegrees);
            Assert.True(aisMessage01.TrueHeadingAvailable);
            Assert.Equal(33, aisMessage01.Timestamp);
            Assert.Equal(AISMessage01.SpecialManoeuvreIndicatorEnum.NotAvailable, aisMessage01.SpecialManoeuvreIndicator);
            Assert.False(aisMessage01.RAIMFlag);
            Assert.Equal(SOTDMACommunicationState.SyncStateEnum.UTCDirect, aisMessage01.CommunicationState.SyncState);
            Assert.Equal(2, aisMessage01.CommunicationState.SlotTimeout);
            Assert.Equal(2, slotTimeout);
            Assert.Equal(1249, slotNumber);
        }
    }
}
