using System;
using System.Collections.Generic;
using TensionDev.Maritime.AIS;
using Xunit;

namespace XUnitTestProjectAIS
{
    public class UnitTestAISMessage18
    {
        [Fact]
        public void AIS18Decoding()
        {
            IList<String> sentences = new List<String>()
            {
                "!AIVDM,1,1,,B,B52K>;h00Fc>jpUlNV@ikwpUoP06,0*4C"
            };

            AISMessage aisMessage = AISMessage.DecodeSentences(sentences);
            AISMessage18 aisMessage18 = aisMessage as AISMessage18;
            ITDMACommunicationState communicationState = aisMessage18.CommunicationState as ITDMACommunicationState;

            Assert.NotNull(aisMessage);
            Assert.NotNull(aisMessage18);
            Assert.NotNull(communicationState);
            Assert.Equal(18, aisMessage18.MessageId);
            Assert.Equal(0, aisMessage18.RepeatIndicator);
            Assert.Equal("338087471", aisMessage18.UserId);
            Assert.Equal(0, aisMessage18.ReservedForRegionalOrLocalApplications);
            Assert.Equal(0.1M, aisMessage18.SpeedOverGroundKnots);
            Assert.True(aisMessage18.SpeedOverGroundAvailable);
            Assert.False(aisMessage18.PositionAccuracy);
            Assert.Equal(-74.072132M, aisMessage18.LongitudeDecimalDegrees, 5);
            Assert.True(aisMessage18.LongitudeAvailable);
            Assert.Equal(40.684540M, aisMessage18.LatitudeDecimalDegrees, 5);
            Assert.True(aisMessage18.LatitudeAvailable);
            Assert.Equal(79.6M, aisMessage18.CourseOverGroundDegrees);
            Assert.True(aisMessage18.CourseOverGroundAvailable);
            Assert.Equal(511, aisMessage18.TrueHeadingDegrees);
            Assert.False(aisMessage18.TrueHeadingAvailable);
            Assert.Equal(49, aisMessage18.Timestamp);
            Assert.True(aisMessage18.RAIMFlag);
            Assert.True(aisMessage18.CommunicationStateSelectorFlag);
            Assert.Equal(AISCommunicationState.SyncStateEnum.SyncToAnotherStation, communicationState.SyncState);
            Assert.Equal(0, communicationState.SlotIncrement);
            Assert.Equal(3, communicationState.NumberOfSlots);
            Assert.False(communicationState.KeepFlag);
        }
    }
}
