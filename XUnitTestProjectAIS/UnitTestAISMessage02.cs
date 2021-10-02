using System;
using System.Collections.Generic;
using TensionDev.Maritime.AIS;
using Xunit;

namespace XUnitTestProjectAIS
{
    public class UnitTestAISMessage02
    {
        [Fact]
        public void AIS02Decoding()
        {
            IList<String> sentences = new List<String>()
            {
                "!AIVDM,1,1,,A,25Mw@DP000qR9bFA:6KI0AV@00S3,0*0A"
            };

            AISMessage aisMessage = AISMessage.DecodeSentences(sentences);
            AISMessage02 aisMessage02 = aisMessage as AISMessage02;

            Assert.NotNull(aisMessage);
            Assert.NotNull(aisMessage02);
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
            Assert.Equal(-90.4067M, aisMessage02.LongitudeDecimalDegrees, 5);
            Assert.True(aisMessage02.LongitudeAvailable);
            Assert.Equal(29.9854616666667M, aisMessage02.LatitudeDecimalDegrees, 5);
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
    }
}
