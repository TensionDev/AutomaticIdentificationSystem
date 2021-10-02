﻿using System;
using System.Collections.Generic;
using TensionDev.Maritime.AIS;
using Xunit;

namespace XUnitTestProjectAIS
{
    public class UnitTestAISMessage03
    {
        [Fact]
        public void AIS02Decoding()
        {
            IList<String> sentences = new List<String>()
            {
                "!AIVDM,1,1,,A,35MC>W@01EIAn5VA4I`N2;>0015@,0*01"
            };

            AISMessage aisMessage = AISMessage.DecodeSentences(sentences);
            AISMessage03 aisMessage03 = aisMessage as AISMessage03;

            Assert.NotNull(aisMessage);
            Assert.NotNull(aisMessage03);
            Assert.Equal(3, aisMessage03.MessageId);
            Assert.Equal(0, aisMessage03.RepeatIndicator);
            Assert.Equal("366268061", aisMessage03.UserId);
            Assert.Equal(AISMessage03.NavigationalStatusEnum.UnderWayUsingEngine, aisMessage03.NavigationalStatus);
            Assert.Equal(0, aisMessage03.RateOfTurnDegreesPerMinute);
            Assert.True(aisMessage03.TurnIndicatorAvailable);
            Assert.True(aisMessage03.TurnInformationAvailable);
            Assert.Equal(8.5M, aisMessage03.SpeedOverGroundKnots);
            Assert.True(aisMessage03.SpeedOverGroundAvailable);
            Assert.False(aisMessage03.PositionAccuracy);
            Assert.Equal(-93.9687666666667M, aisMessage03.LongitudeDecimalDegrees, 5);
            Assert.True(aisMessage03.LongitudeAvailable);
            Assert.Equal(29.829815M, aisMessage03.LatitudeDecimalDegrees, 5);
            Assert.True(aisMessage03.LatitudeAvailable);
            Assert.Equal(359.2M, aisMessage03.CourseOverGroundDegrees);
            Assert.True(aisMessage03.CourseOverGroundAvailable);
            Assert.Equal(359, aisMessage03.TrueHeadingDegrees);
            Assert.True(aisMessage03.TrueHeadingAvailable);
            Assert.Equal(0, aisMessage03.Timestamp);
            Assert.Equal(AISMessage03.SpecialManoeuvreIndicatorEnum.NotAvailable, aisMessage03.SpecialManoeuvreIndicator);
            Assert.False(aisMessage03.RAIMFlag);
            Assert.Equal(ITDMACommunicationState.SyncStateEnum.UTCDirect, aisMessage03.CommunicationState.SyncState);
            Assert.Equal(277, aisMessage03.CommunicationState.SlotIncrement);
            Assert.Equal(0, aisMessage03.CommunicationState.NumberOfSlots);
            Assert.False(aisMessage03.CommunicationState.KeepFlag);
        }
    }
}
